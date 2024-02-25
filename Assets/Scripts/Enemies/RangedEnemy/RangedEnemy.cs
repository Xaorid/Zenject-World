using System.Collections;
using UnityEngine;
using Zenject;

public class RangedEnemy : Enemy
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _throwForce = 5f;

    private bool _isAttacking = false;

    private PlayerBrains _target;
    private DynamitePool _dynamitePool;

    [Inject]
    private void Construct(PlayerBrains target, DynamitePool dynamitePool)
    {
        _target = target;
        _dynamitePool = dynamitePool;
    }

    private void Update()
    {
        CheckDistanceTarget();
    }

    private void CheckDistanceTarget()
    {
        if (_target != null)
        {
            float distanceToTarget = Vector2.Distance(transform.position, _target.transform.position);
            if (distanceToTarget <= _attackRadius)
            {
                var dir = (_target.transform.position - transform.position).normalized;
                if (!_isAttacking)
                {
                    Attack(dir, Damage);
                }
            }
        }
    }

    public override void EnemyMovement()
    {
        if (_target != null && !_isAttacking)
        {
            var dir = (_target.transform.position - transform.position).normalized;
            _rb.velocity = dir * (Speed * Time.deltaTime);
        }
        else
        {
            var dir = -(_target.transform.position - transform.position).normalized;
            _rb.velocity = dir * (Speed * Time.deltaTime);
        }
    }

    private void Attack(Vector2 dir, int damage)
    { 
        OnAttack.Invoke();
        _isAttacking = true;
        StartCoroutine(ThrowDynamite(dir, damage));  
    }

    private IEnumerator ThrowDynamite(Vector2 dir, int damage)
    {
        var dynamite = _dynamitePool.SpawnDynamiteFromPool();
        dynamite.SetDamage(damage);
        dynamite.transform.position = transform.position;
        var dynamiteRb = dynamite.GetComponent<Rigidbody2D>();
        dynamiteRb.AddForce(dir * _throwForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(_attackCooldown);
        ResetParametres();
    }

    private void ResetParametres()
    {
        _isAttacking = false;
    }

    private void OnEnable()
    {
        ResetParametres();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
