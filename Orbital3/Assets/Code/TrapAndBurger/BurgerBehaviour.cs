using Code.Controller;
using Code.Interaction;
using UnityEngine;

namespace Code.TrapAndBurger
{
    public class BurgerBehaviour : MonoBehaviour, IInteractable
    {
        [SerializeField] private float calories;
        
        public void Interact(PlayerController player)
        {
            player.TakeCalories(calories);
            Destroy(gameObject);
        }
    }
}