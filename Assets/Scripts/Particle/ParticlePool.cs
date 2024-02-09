using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    [SerializeField] private PoolableParticle _particlePrefab;
    [SerializeField] private int _poolSize;

    [SerializeField] private Queue<PoolableParticle> particles = new();

    void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var newParticle = CreateNewParticle();
            newParticle.gameObject.SetActive(false);
            particles.Enqueue(newParticle);
        }
    }

    public void SpawnParticleFromPool(Vector3 position)
    {
        if (particles.Count > 0)
        {
            var particleFromPool = particles.Dequeue();
            particleFromPool.transform.position = position;
            particleFromPool.gameObject.SetActive(true);
            particleFromPool.OnSpawnFromPool(this);
        }
        else
        {
            var newParticle = CreateNewParticle();
            newParticle.transform.position = position;
            newParticle.OnSpawnFromPool(this);
        }
    }
    public void ReturnToPool(PoolableParticle particle)
    {
        particle.gameObject.SetActive(false);
        particles.Enqueue(particle);
    }

    private PoolableParticle CreateNewParticle()
    {
        var particle = Instantiate
                (_particlePrefab,
                transform.position,
                Quaternion.identity,
                transform);

        return particle;
    }
}
