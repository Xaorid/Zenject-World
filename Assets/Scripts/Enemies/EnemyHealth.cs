using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _curHealth;

    public static UnityEvent<Vector3> EnemyOnDead = new();

    private void ResetHealth()
    {
        _curHealth = _enemy.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _curHealth -= damage;
        if(_curHealth <= 0)
        {
            EnemyOnDead.Invoke(transform.position);
            _enemy.ReturnToPool();
        }
    }

    private void OnEnable()
    {
        ResetHealth();
    }
}
