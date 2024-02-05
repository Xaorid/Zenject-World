using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Tools
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler Instance;
        
        [Serializable]
        public class Pool
        {
            public string tag;
            public PoolableObject prefab;
            public int size;

            [HideInInspector]
            public GameObject poolParent;
        }

        public List<Pool> pools;
        public Dictionary<string, Queue<PoolableObject>> poolDictionary;

        [Inject]
        private DiContainer _container;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
            
            InitializePool();
        }

        private void OnDisable()
        {
            Instance = null;
        }

        private void InitializePool()
        {
            poolDictionary = new Dictionary<string, Queue<PoolableObject>>();

            foreach (var pool in pools)
            {
                pool.poolParent = new GameObject($"{pool.tag}s");
                pool.poolParent.transform.SetParent(transform);
                
                Queue<PoolableObject> objectsPool = new Queue<PoolableObject>();
                for (var i = 0; i < pool.size; i++)
                {
                    var obj = _container.InstantiatePrefabForComponent<PoolableObject>(pool.prefab, Vector3.zero, Quaternion.identity, pool.poolParent.transform);
                    obj.gameObject.SetActive(false);
                    obj.name += $"_{i}";
                    objectsPool.Enqueue(obj);
                }
            
                poolDictionary.Add(pool.tag, objectsPool);
            }

        }

        public PoolableObject SpawnObjectFromPool(string poolTag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(poolTag))
            {
                Debug.LogWarning("No pool with such tag");
                return null;
            }

            var poolQueue = poolDictionary[poolTag];
            
            if (poolQueue.Count > 0)
            {
                var objFromPool = poolQueue.Dequeue();
                objFromPool.OnSpawnFromPool(position, rotation, poolQueue);
                
                return objFromPool;
            }
            else
            {
                var pool = pools.FirstOrDefault(p => p.tag == poolTag);
                var newObj = _container.InstantiatePrefabForComponent<PoolableObject>(pool.prefab, Vector3.zero, Quaternion.identity, pool.poolParent.transform);
                pool.size++;
                newObj.name += $"_{pool.size}";
                newObj.OnSpawnFromPool(position, rotation, poolQueue);
                
                return newObj;
            }
        }
    }
}
