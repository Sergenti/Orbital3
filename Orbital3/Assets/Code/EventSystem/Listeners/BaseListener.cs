using System;
using Code.EventSystem.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Code.EventSystem.Listeners
{
    public class BaseListener<T, E, UER> : MonoBehaviour, IListener<T> where E : BaseEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E eventToListenTo;
        [SerializeField] private UER response;

        private void OnEnable()
        {
            if (eventToListenTo == null)
            {
                return;
            }
            eventToListenTo.RegisterListener(this);
        }
        
        private void OnDisable()
        {
            if (eventToListenTo == null)
            {
                return;
            }
            eventToListenTo.UnregisterListener(this); 
        }

        public void OnEventRaised(T item)
        {
            response?.Invoke(item);
        }
    }
}