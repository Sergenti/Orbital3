using Code.Controller;
using Code.Interaction;
using UnityEngine;

namespace Code.TrapAndBurger
{
    public class HaieBehaviour : MonoBehaviour, IInteractable
    {
        public void Interact(PlayerController player)
        {
           player.Slow(); 
        }
    }
}