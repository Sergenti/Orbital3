using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject objToSpawn;
        [SerializeField] private Transform downPosition;
        [SerializeField] private Transform upPosition;

        public float spawnRate = 0.1f;

        private float timer = 0f;

        private void Update()
        {
            if (timer <= 0)
            {
                Vector2 randomPosition = new Vector2(upPosition.position.x,Random.Range(upPosition.position.y,downPosition.position.y));
                
                Instantiate(objToSpawn, randomPosition, Quaternion.identity);

                timer = Random.Range(0f, 1 / spawnRate);
            }

            timer -= Time.deltaTime;
        }
    }
}