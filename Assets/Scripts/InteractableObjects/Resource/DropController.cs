using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [SerializeField] private Resource[] _resources;
    [SerializeField] private DifficultController _difficultController;
    [SerializeField] private WaveController _waveController;

    private Dictionary<string, Queue<Resource>> _resourcePool = new ();

    private float _spawnRadius = 0.5f;
    private GameObject _resourcesParent;

    private void Start()
    {
        EnemyHealth.EnemyDead.AddListener(GetMobDrop);
        _resourcesParent = new GameObject("Resources");
        InitializePool();
    }

    private void InitializePool()
    {
        foreach (var resource in _resources)
        {          
            _resourcePool[resource.GetItemName] = new Queue<Resource>();           
        }
    }

    public void GetMobDrop(EnemyDeathInfo enemyDeathInfo)
    {
        foreach (var resource in _resources)
        {
            float randomValue = Random.Range(0, 1f);
            if (randomValue < resource.DropChance)
            {
                Resource droppedResource = GetResourceFromPool(resource);
                droppedResource.transform.position = enemyDeathInfo.Position + Random.insideUnitSphere * _spawnRadius;
                droppedResource.gameObject.SetActive(true);

                if (droppedResource is Gold goldResource)
                {
                    goldResource.RandomizeItemCount(_difficultController.Difficult, _waveController.CurWave, 1f);
                }
            }
        }
    }

    private Resource GetResourceFromPool(Resource resource)
    {
        if (_resourcePool[resource.GetItemName].Count > 0)
        {
            Resource pooledResource = _resourcePool[resource.GetItemName].Dequeue();
            pooledResource.OnSpawnFromPool(this);
            pooledResource.gameObject.SetActive(true);
            return pooledResource;
        }
        else
        {
            Resource newResource = Instantiate(resource, _resourcesParent.transform);
            newResource.OnSpawnFromPool(this);
            return newResource;
        }
    }

    public void ReturnResourceToPool(Resource resource) 
    {
        resource.gameObject.SetActive(false);
        _resourcePool[resource.GetItemName].Enqueue(resource);
    }
}
