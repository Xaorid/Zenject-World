using UnityEngine;
using Zenject;

public class EnemyMelee : Enemy
{
    public override float Speed { get; protected set; }
    public override int MaxHealth { get; protected set; }
    public override int Damage { get; protected set; }

    private Rigidbody2D _rb;
    private Player _target;

    [Inject]
    private void Construct(Player target, float speed, int health, int damage)
    {
        _target = target;
        Speed = speed;
        MaxHealth = health;
        Damage = damage;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    public override void EnemyMovement()
    {
        if (_target != null)
        {
            var dir = (_target.transform.position - transform.position).normalized;
            _rb.velocity = dir * (Speed * Time.deltaTime);
        }
    }

    public override void SetNewEnemyStats(float  speed, int health, int damage)
    {
        Speed = speed;
        MaxHealth = health;
        Damage = damage;
    } 
}
