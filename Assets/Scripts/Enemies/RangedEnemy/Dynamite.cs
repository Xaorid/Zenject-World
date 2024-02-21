using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private float _explosionDelay;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private int _explosionDamage;

    public DynamitePool DynamitePool { get; private set; }

    private void OnEnable()
    {
        StartCoroutine(ExplodeAfterDelayRoutine(_explosionDelay));
    }

    private IEnumerator ExplodeAfterDelayRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool();
        Explosion();
    }

    private void Explosion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(_explosionDamage);
                }
            }
        }
    }
    private void ReturnToPool()
    {
        DynamitePool.ReturnToPool(this);
    }

    public void SpawnFromPool(DynamitePool pool)
    {
        DynamitePool = pool;
    }

    public void SetDamage(int damage)
    {
        _explosionDamage = damage;
    }
}
