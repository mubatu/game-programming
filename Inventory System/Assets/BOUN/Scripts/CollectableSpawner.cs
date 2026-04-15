using System.Collections.Generic;
using EventModule;
using UnityEngine;

namespace BOUN.Scripts
{
    public class CollectableSpawner : MonoBehaviour
    {
        public int coinCount = 10;
        // todo: Add fuelCount
        public int fuelCount = 3;
        public float areaWidth = 10f;
        public float areaHeight = 30f;
        public int seed = 42;
        
        private Collectable coinPrefab => Resources.Load<Collectable>("CollectableCoin");
        private Collectable fuelPrefab => Resources.Load<Collectable>("CollectableFuel");
        private List<Collectable> coinPool = new List<Collectable>();
        private List<Collectable> fuelPool = new List<Collectable>();
        
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
            for (int i = 0; i < fuelCount; i++)
            {
                Collectable fuel = Instantiate(fuelPrefab, Vector3.zero, Quaternion.identity, transform);
                fuel.gameObject.SetActive(false);
                fuelPool.Add(fuel);
            }
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
            foreach (Collectable fuel in fuelPool)
            {
                Vector3 randomPosition = new Vector3(
                    (float)(random.NextDouble() * areaWidth - areaWidth / 2),
                    1f,
                    (float)(random.NextDouble() * areaHeight - areaHeight / 2)
                );
                fuel.transform.position = randomPosition;
                fuel.gameObject.SetActive(true);
                fuel.Activate();
            }
            
        }
    }
}