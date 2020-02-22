using System.Collections.Generic;
using Code.EventSystem.Listeners;
using UnityEngine;

namespace Code.EventSystem.Events
{
    public abstract class BaseEvent<T> : ScriptableObject
    {
       private readonly List<IListener<T>> listeners = new List<IListener<T>>();

       public void RegisterListener(IListener<T> listener)
       {
           if(listener == null || listeners.Contains(listener)) {return;}
           listeners.Add(listener);
       }

       public void UnregisterListener(IListener<T> listener)
       {
           if(listener == null){return;}

           if (listeners.Contains(listener))
           {
               listeners.Remove(listener);
           }
       }

       public void Raise(T item)
       {
           for (int i = listeners.Count - 1; i >= 0; i--)
           {
               listeners[i].OnEventRaised(item);
           }
       }
    }
}