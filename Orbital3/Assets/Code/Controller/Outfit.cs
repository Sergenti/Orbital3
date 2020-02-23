using System;
using Code.Movement;
using UnityEngine;

namespace Code.Controller
{
    public class Outfit : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        
        private Animator animator;
        private Color color;
        private static readonly int WeightIdx = Animator.StringToHash("WeightIdx");
        private SpriteRenderer sprite;

        private void Start()
        {
            animator = GetComponent<Animator>();
            color = stats.color;
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
           animator.SetInteger(WeightIdx,stats.weightLevelIdx);
           sprite.color = stats.color;
        }
    }
}