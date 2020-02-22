using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Movement
{
    [CreateAssetMenu(fileName = "new Player Stats", menuName = "Player/Stats", order = 0)]
    public class PlayerStats : ScriptableObject
    {
        public float calories;
        public int weightLevelIdx;
        public bool isAlive = true;
        public WeightLevelList WeightLevels;

        public bool CheckCalories()
        {
            if (weightLevelIdx != WeightLevels.weightLevels.Count - 1 &&
                calories > WeightLevels.weightLevels[weightLevelIdx + 1].caloriesThreshold)
            {
                weightLevelIdx++;
                return true;
            }
            if (weightLevelIdx != 0 &&
                     calories < WeightLevels.weightLevels[weightLevelIdx].caloriesThreshold)
            {
                weightLevelIdx--;
                return true;
            }

            return false;
        }

        public void OnEnable()
        {
            Debug.Log(("Recalculate"));
            calories = 100;
            weightLevelIdx = 0;
            isAlive = true;
        }

        
    }
}