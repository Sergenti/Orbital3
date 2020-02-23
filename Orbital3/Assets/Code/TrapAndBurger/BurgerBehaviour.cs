using System;
using Code.Controller;
using Code.Interaction;
using UnityEngine;

namespace Code.TrapAndBurger
{
    public class BurgerBehaviour : MonoBehaviour, IInteractable
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private float calories;
        
        private void Start()
        {
           Destroy(gameObject,10f);
        }
        public void Interact(PlayerController player)
        {
            AudioSource.PlayClipAtPoint(clip, player.transform.position);
            player.TakeCalories(calories);
            Destroy(gameObject);
        }
    }
}