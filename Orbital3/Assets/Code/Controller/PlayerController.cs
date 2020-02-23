using System;
using Code.Interaction;
using Code.Movement;
using Code.TrapAndBurger;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputRef inputRef;
        [SerializeField] private float dashForce = 1f;
        [SerializeField] private PlayerStats stats;
        [SerializeField] private float slowFactor = 1;

        private PlayerMovement m_playerMovement;
        private float m_speed;
        private CircleCollider2D collider;
        private Rigidbody2D rb;
        private float caloPerSec = 20;
        private Animator _animator;
        private static readonly int WeightIdx = Animator.StringToHash("WeightIdx");

        private void Start()
        {
            stats.Reset();
            m_playerMovement = GetComponent<PlayerMovement>();
            collider = GetComponent<CircleCollider2D>();
            m_speed = stats.WeightLevels.weightLevels[stats.weightLevelIdx].speed;
            rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            
            if (stats.CheckCalories())
            {
                RecalculateSize();
            }
            else if(stats.calories <= 0 || stats.isAlive == false) //|| stats.calories >= PlayerStats.MAX_CALORIES)
            {
               Die(); 
            }
            m_playerMovement.Move(inputRef.GetVector(),m_speed*slowFactor);

            stats.calories -= caloPerSec * Time.deltaTime;

           if (Input.GetButtonDown(inputRef.DashButton) && stats.weightLevelIdx >= 2)
           {
               m_playerMovement.Dash(dashForce);
               stats.calories -= 100f;
           }
        }

        public void Dash(Vector2 moveVector)
        {
            m_playerMovement.ForceDash(dashForce*moveVector);
        }

        private void RecalculateSize()
        {
            collider.radius = stats.WeightLevels.weightLevels[stats.weightLevelIdx].bodyRadius;
            m_speed = stats.WeightLevels.weightLevels[stats.weightLevelIdx].speed;
            collider.sharedMaterial = stats.WeightLevels.weightLevels[stats.weightLevelIdx].physicMaterial;
            rb.sharedMaterial = stats.WeightLevels.weightLevels[stats.weightLevelIdx].physicMaterial;
            _animator.SetInteger(WeightIdx,stats.weightLevelIdx);
        }

        public void TakeCalories(float calories)
        {
            stats.calories += calories;
        }

        public void Die()
        {
            stats.isAlive = false;
            Destroy(gameObject);
        }

        public void Slow()
        {
            slowFactor = 0.4f;
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
                return new Vector2(UnityEngine.Input.GetAxisRaw(xAxis),UnityEngine.Input.GetAxisRaw(yAxis)); 
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            
            interactable?.Interact(this);

            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            
            if (playerController != null && m_playerMovement.isDashing)
            {
                 playerController.Dash(m_playerMovement.m_moveVector*stats.weightLevelIdx);
            }
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            HaieBehaviour haieBehaviour = other.gameObject.GetComponent<HaieBehaviour>();
            
            if (haieBehaviour != null)
            {
                slowFactor = 1f;
            }
        }
    }
}