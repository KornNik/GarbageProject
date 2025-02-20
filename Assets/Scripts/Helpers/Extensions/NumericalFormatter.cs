using System.Numerics;

public static class NumericalFormatter 
{
    public static string Format(BigInteger number)
    {
        return FormatNumberString(number.ToString());
    }

    public static string FormatNumberString(string number)
    {
        if (number.Length < 4)
        {
            return number;
        }

        return FormatGeneral(number);
    }

    private static string FormatGeneral(string number)
    {
        int length = number.Length;
        int amountOfLeadingNumbers = (length - 1) % 3 + 1;
        string leadingNumbers = number.Substring(0, amountOfLeadingNumbers);
        string decimals = number.Substring(amountOfLeadingNumbers, 2); // Get two decimal places
        string suffix = GetSuffixForNumber(length);
        
        // Handle rounding the decimals
        if (number.Length > amountOfLeadingNumbers + 2)
        {
            int nextDigit = int.Parse(number.Substring(amountOfLeadingNumbers + 2, 1));
            if (nextDigit >= 5)
            {
                BigInteger roundedValue = BigInteger.Parse(leadingNumbers + decimals) + 1;
                leadingNumbers = roundedValue.ToString().Substring(0, roundedValue.ToString().Length - 2);
                decimals = roundedValue.ToString().Substring(roundedValue.ToString().Length - 2);
            }
        }

        return $"{leadingNumbers}.{decimals}{suffix}";
    }

    private static string GetSuffixForNumber(int length)
    {
        int numberOfThousands = (length - 1) / 3;

        switch (numberOfThousands)
        {
            case 1:
                return "K";
            case 2:
                return "M";
            case 3:
                return "B";
            case 4:
                return "T";
            case 5:
                return "Q";
            default:
                return GetProceduralSuffix(numberOfThousands - 5);
        }
    }

    private static string GetProceduralSuffix(int numberOfThousandsAfterQ)
    {
        if (numberOfThousandsAfterQ < 26)
        {
            return ((char)(numberOfThousandsAfterQ + 'a')).ToString();
        }

        int rightChar = (numberOfThousandsAfterQ % 26);
        string right = rightChar == 0 ? "z" : ((char)(rightChar + 'a')).ToString();
        string left = ((char)(((numberOfThousandsAfterQ - 1) / 26) + 'a')).ToString();

        return left + right;
    }
}