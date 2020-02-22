using Code.Controller;
using Code.Interaction;
using UnityEngine;

namespace Code.TrapAndBurger
{
    public class HoleBehaviour : MonoBehaviour, IInteractable
    {
        public void Interact(PlayerController player)
        {
            player.Die();
        }
    }
}