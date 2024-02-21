using System.Collections;
using UnityEngine;
using Zenject;

public class RangedEnemy : Enemy
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _throwForce = 5f;

    private bool isAttacking = false;
    private bool _playerIsRange = false;

    private Player _target;
    private DynamitePool _dynamitePool;

    [Inject]
    private void Construct(Player target, DynamitePool dynamitePool)
    {
        _target = target;
        _dynamitePool = dynamitePool;
    }

    public override void EnemyMovement()
    {
        if (_target != null || isAttacking)
        {
            var dir = (_target.transform.position - transform.position).normalized;
            _rb.velocity = dir * (Speed * Time.deltaTime);
        }
    }

    private void Attack(Vector2 dir, int damage)
    { 
        isAttacking = true;
        StartCoroutine(ThrowDynamite(dir, damage));  
    }

    private IEnumerator ThrowDynamite(Vector2 dir, int damage)
    {
        yield return new WaitForSeconds(_attackCooldown);

        var dynamite = _dynamitePool.SpawnDynamiteFromPool();
        dynamite.SetDamage(damage);
        dynamite.transform.position = transform.position;
        var dynamiteRb = dynamite.GetComponent<Rigidbody2D>();
        dynamiteRb.AddForce(dir * _throwForce, ForceMode2D.Impulse);

        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerIsRange = true;
            var dir = (collision.transform.position - transform.position).normalized;
            if (!isAttacking)
            {
                Attack(dir, Damage);    
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerIsRange = false;
    }
}
