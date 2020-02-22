using System;
using Code.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class MaskedGauge : MonoBehaviour
    {
        [SerializeField] private Image gaugeSprite;
        [SerializeField] private Transform startPosition;
        [SerializeField] private PlayerStats stats;

        private float m_percentage = 100;
        private float maxPosition;
        private float distance;
        private RectTransform rectTransform;

        private void Start()
        {
            maxPosition = transform.position.x;
            distance = maxPosition - startPosition.position.x;
            rectTransform = GetComponent<RectTransform>();
        }

        public void SetPercent(float percentage)
        {
            m_percentage = percentage;
        }

        private void Update()
        {
            SetPercent(stats.calories/10f);
            //rectTransform.SetPositionAndRotation(startPosition.position + Vector3.right * (distance * m_percentage)/100f,Quaternion.identity);
            
            
            gaugeSprite.rectTransform.SetPositionAndRotation(new Vector3(-(distance*m_percentage)/100f,gaugeSprite.rectTransform.position.y,gaugeSprite.rectTransform.position.z),Quaternion.identity);
        }
    }
}