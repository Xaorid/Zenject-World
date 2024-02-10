using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStats _enemyStats;
    public EnemyStats EnemyStats { get { return _enemyStats; } }
    public int MaxHealth { get; protected set; }
    public int Damage { get; protected set; }
    public float Speed { get; protected set; }

    public EnemySpawner EnemyPool { get; private set;}

    public static UnityEvent<int> OnDealDamage = new();

    public abstract void EnemyMovement();

    public virtual void SetNewEnemyStats(float speed, int health, int damage)
    {
        Speed = speed;
        MaxHealth = health;
        Damage = damage;
    }

    public void OnSpawnFromPool(EnemySpawner pool)
    {
        EnemyPool = pool;
    }

    public void ReturnToPool()
    {
        EnemyPool.ReturnToPool(this);
    }
}
