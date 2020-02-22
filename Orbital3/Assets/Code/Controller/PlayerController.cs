using System;
using Code.Interaction;
using Code.Movement;
using UnityEngine;

namespace Code.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputRef inputRef;
        [SerializeField] private float dashForce = 1f;
        [SerializeField] private PlayerStats stats;

        private PlayerMovement m_playerMovement;
        private float m_speed;
        private CircleCollider2D collider;

        private void Start()
        {
            m_playerMovement = GetComponent<PlayerMovement>();
            collider = GetComponent<CircleCollider2D>();
            m_speed = stats.WeightLevels.weightLevels[stats.weightLevelIdx].speed;
        }

        private void Update()
        {
            if (stats.CheckCalories())
            {
                RecalculateSize();
            }
            m_playerMovement.Move(inputRef.GetVector(),m_speed);

           if (Input.GetButtonDown(inputRef.DashButton))
           {
               m_playerMovement.Dash(dashForce);
           }
        }

        private void RecalculateSize()
        {
            collider.radius = stats.WeightLevels.weightLevels[stats.weightLevelIdx].bodyRadius;
            //Change Sprite
            m_speed = stats.WeightLevels.weightLevels[stats.weightLevelIdx].speed;
        }

        public void TakeCalories(float calories)
        {
            stats.calories += calories;
        }

        public void Die()
        {
            stats.isAlive = false;
        }

        private void CheckCaloriesLevel()
        {
            if(stats.calories <= 0)
                Die();
           
        }

        private void LoseWeight()
        {
            
        }

        private void GainWeight()
        {
            
        }
        
        [System.Serializable]
        private struct InputRef
        {
            [SerializeField] private string xAxis;
            [SerializeField] private string yAxis;
            [SerializeField] private string dashButton;

            public string DashButton => dashButton;

            public Vector2 GetVector()
            {
                return new Vector2(UnityEngine.Input.GetAxis(xAxis),UnityEngine.Input.GetAxis(yAxis)); 
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            
            interactable?.Interact(this);
        }
    }
}