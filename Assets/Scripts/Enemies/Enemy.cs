using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStats _enemyStats;
    public EnemyStats EnemyStats { get { return _enemyStats; } }
    public int MaxHealth { get; protected set; }
    public int Damage { get; protected set; }
    public float Speed { get; protected set; }
    public float Exp { get; protected set; }

    public EnemySpawner EnemyPool { get; private set; }

    [HideInInspector]
    public UnityEvent OnAttack = new();
    public static UnityEvent<int> OnDealDamage = new();

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    public abstract void EnemyMovement();
    public virtual void SetNewEnemyStats(float speed, int health, int damage, float exp)
    {
        Speed = speed;
        MaxHealth = health;
        Damage = damage;
        Exp = exp;
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
