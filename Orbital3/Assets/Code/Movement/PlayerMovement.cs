using System;
using UnityEngine;

namespace Code.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D m_rb;
        private Vector2 m_moveVector;
        private float m_speed = 0f;

        private void Start()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_rb.gravityScale = 0f; //No gravity here
        }

        private void FixedUpdate()
        {
           m_rb.MovePosition(m_rb.position + m_moveVector * (m_speed * Time.fixedDeltaTime)); 
        }

        /// <summary>
        /// Move the rigidbody2d according to the direction and speed. 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public void Move(Vector2 direction, float speed)
        {
            m_moveVector = direction;
            if (m_moveVector.magnitude > 1)
            {
                m_moveVector.Normalize();
            }
            
            m_speed = speed;
        }

        public void Dash(float dashForce)
        {
           m_rb.AddForce(m_moveVector * dashForce); 
        }
            
    }
}
