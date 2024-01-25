using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class PoolableObject : MonoBehaviour
    {
        private Queue<PoolableObject> ownerPool;
        public void OnSpawnFromPool(Vector3 position, Quaternion rotation,  Queue<PoolableObject> fromPool)
        {
            ownerPool = fromPool;
            transform.position = position;
            transform.rotation = rotation;
            gameObject.SetActive(true);
            
            OnSpawned();
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
            ownerPool?.Enqueue(this);
            
            OnReturnedToPool();
        }

        /// <summary>
        /// Used to implement additional logic that will be executed after spawning object from the pool.
        /// Note that position, rotation and .setActive is controlled via PoolableObject.OnSpawnFromPool
        /// </summary>
        protected virtual void OnSpawned(){}
        
        /// <summary>
        /// Used to implement additional logic that will be executed after returning object to the pool.
        /// Note .setActive is controlled via PoolableObject.ReturnToPool
        /// </summary>
        protected virtual void OnReturnedToPool(){}
    }
}
