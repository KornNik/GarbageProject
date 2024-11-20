Shader "Hidden/Smooth Outlines Effect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
			"RenderPipeline" = "UniversalPipeline"
		}

		HLSLINCLUDE

		#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
		#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
		#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"

		#pragma multi_compile_local _ USE_TIGHT_MASK
		#pragma multi_compile_local _ USE_DISTANCE_FADE
		#pragma multi_compile_local _ USE_CURVATURE_BLEND

		#define MAX_HALF_EXTENT 4

		TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);
		float4 _MainTex_TexelSize;

		TEXTURE2D(_Mask);
		SAMPLER(sampler_Mask);

		uniform int _KernelHalfExtent;

		uniform float _NormalThreshold;
		uniform float _CurvatureThresholdsContribution;

		uniform float _DepthThreshold;
		uniform float _DepthThresholdDistanceContribution;
		uniform float _DepthThresholdViewAlignmentContribution;

		uniform float _ColourThreshold;

		uniform float _OutlineThickness;
		uniform float _OutlineSoftness;
		uniform float _Intensity;
		uniform float4 _OutlineColour;
		uniform float4 _ConcavityColour;
		uniform float4 _ConvexityColour;

		uniform float _DistanceFadeStart;
		uniform float _DistanceFadeEnd;

		struct appdata
		{
			float4 positionOS : POSITION;
			float2 uv : TEXCOORD0;
		};

		struct v2f
		{
			float4 positionCS : SV_POSITION;
			float2 uv : TEXCOORD0;
		};

		v2f vert(appdata v)
		{
			v2f o;
			o.positionCS = TransformObjectToHClip(v.positionOS.xyz);
			o.uv = v.uv;
			return o;
		}

		float3 TransformUVToWorldPos(float2 screenUV, out float rawDepth)
		{
			#if UNITY_REVERSED_Z
			    rawDepth = SampleSceneDepth(screenUV);
			#else
			    // Adjust Z to match NDC for OpenGL ([-1, 1])
			    rawDepth = lerp(UNITY_NEAR_CLIP_VALUE, 1, SampleSceneDepth(screenUV));
			#endif

			// Reconstruct the world space positions.
			float3 positionWS = ComputeWorldSpacePosition(screenUV, rawDepth, UNITY_MATRIX_I_VP);

			return positionWS;		
		}

		float GetLinearEyeDepth(float rawDepth)
		{
			float ortho = unity_OrthoParams.w;

			float orthoLinearDepth = _ProjectionParams.x > 0 ? rawDepth : 1 - rawDepth;
			float orthoEyeDepth = lerp(_ProjectionParams.y, _ProjectionParams.z, orthoLinearDepth);

			return LinearEyeDepth(rawDepth, _ZBufferParams) * (1.0f - ortho) +
					orthoEyeDepth * ortho;
		}

		float3 ViewDirectionFromUV(float2 uv)
		{
			float2 p_11_22 = float2(unity_CameraProjection._11, unity_CameraProjection._22);
			return -normalize(float3((uv * 2.0f - 1.0f) / p_11_22, -1.0f));
		}

		float GetMask(float2 uv)
		{
			float maskCentre = SAMPLE_TEXTURE2D(_Mask, sampler_Mask, uv).r;

			#if USE_TIGHT_MASK || USE_DISTANCE_FADE
				return maskCentre;
			#endif

			float halfExtent = min(_KernelHalfExtent, MAX_HALF_EXTENT);
			float maskSampleOffset = halfExtent + 1.0f;
			float maskRight =	SAMPLE_TEXTURE2D(_Mask, sampler_Mask, uv + float2(maskSampleOffset, 0 ) * _MainTex_TexelSize.x).r;
			float maskLeft =	SAMPLE_TEXTURE2D(_Mask, sampler_Mask, uv + float2(-maskSampleOffset, 0) * _MainTex_TexelSize.x).r;
			float maskUp =		SAMPLE_TEXTURE2D(_Mask, sampler_Mask, uv + float2(0, maskSampleOffset ) * _MainTex_TexelSize.y).r;
			float maskDown =	SAMPLE_TEXTURE2D(_Mask, sampler_Mask, uv + float2(0, -maskSampleOffset) * _MainTex_TexelSize.y).r;

			float maxMask = max(max(max(maskRight, maskLeft), max(maskUp, maskDown)), maskCentre);
			return maxMask;
		}

		float GetCurvature(float3 normalWS, float rawDepth)
		{
			float3 normalVS = mul((float3x3)unity_WorldToCamera, normalWS);

			float3 dnx = ddx(normalVS);
			float3 dny = ddy(normalVS);

			float3 normalRight = normalVS + dnx;
			float3 normalLeft = normalVS - dnx;
			float3 normalUp = normalVS + dny;
			float3 normalDown = normalVS - dny;

			float linearEyeDepth = GetLinearEyeDepth(rawDepth);
			float ds = 1.0f + fwidth(linearEyeDepth);
			float dn = (normalRight.x - normalLeft.x) + (normalUp.y - normalDown.y);

			float curvature = dn / ds;

			#define CURVATURE_EXCESS_THRESHOLD 0.5f
			return curvature * step(length(dnx) + length(dny), CURVATURE_EXCESS_THRESHOLD);
		}

		float GetDepthThreshold(float2 uv, float3 normalWS, float rawDepth, float unsignedCurvature)
		{
			float3 viewDirection = ViewDirectionFromUV(uv);
			float3 normalVS = mul((float3x3)unity_WorldToCamera, normalWS);
			float normalViewAlignment = dot(-normalVS, viewDirection);

			float linearEyeDepth = GetLinearEyeDepth(rawDepth);

			float normalViewIntensity = 1.0f / (2.0f - normalViewAlignment);
			float depthFactor = linearEyeDepth / (linearEyeDepth + 1.0f);
			float curvatureFactor = 1.0f + unsignedCurvature / (unsignedCurvature + 1.0f);

			return pow(_DepthThreshold,
						pow(normalViewIntensity, _DepthThresholdViewAlignmentContribution)) *
				   pow(depthFactor, _DepthThresholdDistanceContribution) *
				   pow(curvatureFactor, _CurvatureThresholdsContribution);
		}

		float GetNormalThreshold(float unsignedCurvature)
		{
			float curvatureFactor = 1.0f / (unsignedCurvature + 1.0f);
			return _NormalThreshold * pow(curvatureFactor, _CurvatureThresholdsContribution);
		}

		float GetColourTheshold(float unsignedCurvature)
		{
			float curvatureFactor = 1.0f + unsignedCurvature / (unsignedCurvature + 1.0f);
			return _ColourThreshold * pow(curvatureFactor, _CurvatureThresholdsContribution);
		}

		//Used to give higher precision to such low values
		float RemapDistance(float d)
		{
			static const float F = 0.995f;
			float a = 1.0f / F;
			return a * d / (d + a - 1.0f);
		}

		ENDHLSL

		Pass
		{
			Name "Outline SDF Computation"
			
			HLSLPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			float GetMinDistanceToEdges(float2 uv, float3 colour, out float curvature)
			{
				float lowQualityDepth = 0.0f;
				float minDistance = 1.0f;

				float rawDepth = 0.0f;
				float3 normalWS = SampleSceneNormals(uv);
				float3 positionWS = TransformUVToWorldPos(uv, rawDepth);

				curvature = 0.0f;
				float unsignedCurvature = abs(GetCurvature(normalWS, rawDepth));
				float normalThreshold = GetNormalThreshold(unsignedCurvature);
				float depthThreshold = GetDepthThreshold(uv, normalWS, rawDepth, unsignedCurvature);
				float colourThreshold = GetColourTheshold(unsignedCurvature);

				float halfExtent = min(_KernelHalfExtent, MAX_HALF_EXTENT);
				float2 aspectRatioCorection = float2(_ScreenParams.x / 960.0f, _ScreenParams.y / 540.0f);

				[loop]
				for (int x = -halfExtent; x <= halfExtent; x++)
				{
					[loop]
					for (int y = -halfExtent; y <= halfExtent; y++)
					{
						float2 displacement = float2(x, y) * _MainTex_TexelSize.xy * aspectRatioCorection;
						float2 neighborUV = uv + displacement;

						float3 neighborNormalWS = SampleSceneNormals(neighborUV);

						float neighborRawDepth = 0.0f;
						float3 neighborPositionWS = TransformUVToWorldPos(neighborUV, neighborRawDepth);
						float3 neighborColour = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, neighborUV).rgb;

						float signedPlaneDistance = dot(normalWS, neighborPositionWS - positionWS);
						float planeDistance = abs(signedPlaneDistance);
						float sphereDistance = distance(neighborPositionWS, positionWS - normalWS * (1.0f / (unsignedCurvature + 1.0f)));
						float geometricalDistance = lerp(planeDistance, sphereDistance, unsignedCurvature);
						curvature -= signedPlaneDistance;

						float normalDistance = dot(normalWS, neighborNormalWS);
						float colourDistance = distance(colour, neighborColour);
						
						if (geometricalDistance > depthThreshold ||
							normalDistance < normalThreshold ||
							colourDistance > colourThreshold)
						{
							minDistance = min(minDistance, distance(uv, neighborUV));
						}
					}
				}

				float linearEyeDepth = GetLinearEyeDepth(rawDepth);
				float ds = 0.001f + fwidth(linearEyeDepth);
				curvature /= ds;

				return minDistance;
			}

			float4 frag(v2f i) : SV_TARGET
			{				
				float mask = GetMask(i.uv);
				float3 colour = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv).rgb;
				
				static const float MASK_EDGE = 0.999f;
				if (mask < MASK_EDGE) return float4(1.0f, 0.0f, 0.0f, 0.0f);

				float curvature;
				float minDistance = GetMinDistanceToEdges(i.uv, colour, curvature);

				//Remap for texture
				curvature = curvature * 0.5f + 0.5f;
				minDistance = RemapDistance(minDistance);
				return float4(minDistance, curvature, 0.0f, 0.0f);
			}

			ENDHLSL
		}

		Pass
		{
			Name "Outline Draw"
			Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency

			HLSLPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			float4 DrawAntialiasedSDFContour(float minDistance, float rawDepth)
			{
				float linearEyeDepth = GetLinearEyeDepth(rawDepth);
				float edge = smoothstep(1.0f - (_OutlineThickness) - _OutlineSoftness,
										1.0f - (_OutlineThickness) + _OutlineSoftness,
										minDistance);
				
				#if USE_DISTANCE_FADE
					edge *= 1.0f - smoothstep(_DistanceFadeStart, _DistanceFadeEnd, linearEyeDepth);
				#endif
				return float4(_OutlineColour.rgb, _OutlineColour.a * edge);
			}

			float4 Overlay(float4 a, float4 b)
			{
				return (2 * a * b) * step(0.5, a) + (1 - 2 * (1 - a) * (1 - b)) * step(a, 0.5);
			}

			float4 frag(v2f i) : SV_TARGET
			{
				float4 minDistanceData = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);

				//These are encoded from the previous pass
				float minDistance = minDistanceData.r;

				float rawDepth = 0.0f;
				#if UNITY_REVERSED_Z
					rawDepth = SampleSceneDepth(i.uv);
				#else
					// Adjust Z to match NDC for OpenGL ([-1, 1])
					rawDepth = lerp(UNITY_NEAR_CLIP_VALUE, 1, SampleSceneDepth(i.uv));
				#endif

				float adjustedDistance = 1.0f - pow(minDistance, _Intensity);
				float4 outline = DrawAntialiasedSDFContour(adjustedDistance, rawDepth);

				#if USE_CURVATURE_BLEND
					float remappedCurvature = saturate(minDistanceData.g);
					outline.rgb = Overlay(outline, lerp(_ConcavityColour, _ConvexityColour, remappedCurvature)).rgb;
				#endif

				return outline;
			}

			ENDHLSL
		}
	}
}