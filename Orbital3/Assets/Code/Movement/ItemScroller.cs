using System;
using UnityEngine;

namespace Code.Movement
{
    public class ItemScroller : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        private void Update()
        {
            var position = transform.position;
            transform.SetPositionAndRotation(new Vector3(position.x-speed*Time.deltaTime,position.y),Quaternion.identity);
        }
    }
}