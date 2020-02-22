using System.Collections.Generic;
using UnityEngine;

namespace Code.Movement
{
    [CreateAssetMenu(fileName = "new Weight List", menuName = "Weight/List", order = 0)]
    public class WeightLevelList : ScriptableObject
    {
        public List<WeightLevel> weightLevels = new List<WeightLevel>();
        
        [System.Serializable]
        public struct WeightLevel
        {
            public float caloriesThreshold;
            public string name;
            public float speed;
            public float bodyRadius;
        }
    }

    
}