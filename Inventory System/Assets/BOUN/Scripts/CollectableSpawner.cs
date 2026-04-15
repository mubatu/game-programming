using System.Collections.Generic;
using EventModule;
using UnityEngine;

namespace BOUN.Scripts
{
    public class CollectableSpawner : MonoBehaviour
    {
        public int coinCount = 10;
        // todo: Add fuelCount
        public float areaWidth = 10f;
        public float areaHeight = 30f;
        public int seed = 42;
        
        private Collectable coinPrefab => Resources.Load<Collectable>("CollectableCoin");
        private List<Collectable> coinPool = new List<Collectable>();
        
        private System.Random random;

        void Start()
        {
            random = new System.Random(seed);
            InitializePool();
            EventController.AddEventListener<OnPathFinished>(data => SpawnCollectables());
            SpawnCollectables();
        }
    

        void OnDestroy()
        {
            EventController.RemoveEventListener<OnPathFinished>(data => SpawnCollectables());
        }

        void InitializePool()
        {
            for (int i = 0; i < coinCount; i++)
            {
                Collectable coin = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity, transform);
                coin.gameObject.SetActive(false);
                coinPool.Add(coin);
            }
            // todo: Add fuel to the pool
        }

        void SpawnCollectables()
        {
            foreach (Collectable coin in coinPool)
            {
                Vector3 randomPosition = new Vector3(
                    (float)(random.NextDouble() * areaWidth - areaWidth / 2),
                    1f,
                    (float)(random.NextDouble() * areaHeight - areaHeight / 2)
                );
            
                coin.transform.position = randomPosition;
                coin.gameObject.SetActive(true);
                coin.Activate();
            }
            // todo: Spawn fuel objects
        }
    }
}