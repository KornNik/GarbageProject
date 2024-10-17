using Behaviours.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitsPrefabs", menuName = "Data/Units/Prafabs")]
    sealed class UnitsPrafabsData : ScriptableObject
    {
        [SerializeField] private UnitController _playerUnit;
        [SerializeField] private HashSet<GameObject> _otherUnits;

        public UnitController GetPlayer()
        {
            return _playerUnit;
        }
    }
}
