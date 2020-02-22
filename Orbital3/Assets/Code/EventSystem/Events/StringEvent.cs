using UnityEngine;

namespace Code.EventSystem.Events
{
    [CreateAssetMenu(fileName = "New string Event",menuName = "Event/String",order = 1)]
    public class StringEvent : BaseEvent<string>
    {
        
    }
}