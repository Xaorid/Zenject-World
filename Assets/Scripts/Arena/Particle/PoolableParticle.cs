using System.Collections;
using UnityEngine;

public class PoolableParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _lifeTime;
    private ParticlePool _particlePool;

    private void Start()
    {
        _lifeTime = _particleSystem.main.duration;
    }

    public void OnSpawnFromPool(ParticlePool pool)
    {
        _particlePool = pool;
        _particleSystem.Play();
        StartCoroutine(LifetimeRoutine());
    }

    private void ReturnToPool()
    {
        _particlePool.ReturnToPool(this);
    }

    private IEnumerator LifetimeRoutine()
    {
        yield return new WaitForSeconds(_lifeTime);
        ReturnToPool();
    }
}
