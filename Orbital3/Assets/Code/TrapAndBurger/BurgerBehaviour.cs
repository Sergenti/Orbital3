using System;
using Code.Controller;
using Code.Interaction;
using UnityEngine;

namespace Code.TrapAndBurger
{
    public class BurgerBehaviour : MonoBehaviour, IInteractable
    {
        [SerializeField] private float calories;


        private void Start()
        {
           Destroy(gameObject,10f); 
        }

        public void Interact(PlayerController player)
        {
            player.TakeCalories(calories);
            Destroy(gameObject);
        }
    }
}