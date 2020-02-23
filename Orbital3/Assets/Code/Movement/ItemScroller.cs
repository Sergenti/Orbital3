using System;
using UnityEngine;

namespace Code.Movement
{
    public class ItemScroller : MonoBehaviour
    {
        private float speed = 2f;

        void Start()
        {
            speed = UnityEngine.Object.FindObjectOfType<TerrainScroller>().scrollSpeed;
        }
        private void Update()
        {
            var position = transform.position;
            transform.SetPositionAndRotation(new Vector3(position.x - speed * Time.deltaTime, position.y), Quaternion.identity);
        }
    }
}