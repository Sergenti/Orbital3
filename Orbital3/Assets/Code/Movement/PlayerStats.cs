using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Code.EventSystem.Events;

namespace Code.Movement
{
    [CreateAssetMenu(fileName = "new Player Stats", menuName = "Player/Stats", order = 0)]
    public class PlayerStats : ScriptableObject
    {
        public float calories;
        public int weightLevelIdx;
        public bool isAlive = true;
        public WeightLevelList WeightLevels;
        public static float MAX_CALORIES = 1000f;
        public Color color;
        public string playerName;
        public VoidEvent cameraShakeEvent;
        public GameObject deathEffect;
        

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
            calories = 200f;
            weightLevelIdx = 0;
            isAlive = true;
        }

        public void Reset()
        {
            calories = 200f;
            weightLevelIdx = 0;
            isAlive = true;
        }
    }
}