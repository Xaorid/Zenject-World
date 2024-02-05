using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;

    public float Speed { get; private set; }
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public float EnemyScale { get; private set; }

    private Player _target;

    [Inject]
    private void Construct(Player target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if (_target != null)
        {
            var dir = (_target.transform.position - transform.position).normalized;
            _rb.velocity = dir * (Speed * Time.deltaTime);
        }
    }

    public void SetEnemyStats(float  speed, int health, int damage, float enemyScale)
    {
        Speed = speed;
        Health = health;
        Damage = damage;
        EnemyScale = enemyScale;
    } 
}
