using System.Collections;
using UnityEngine;
using Zenject;

public class MeleeEnemy : Enemy
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _attackCooldown = 1f;
    private bool _isAttacking = false;

    private Player _target;

    [Inject]
    private void Construct(Player target)
    {
        _target = target;
    }

    private void Start()
    {
        PlayerHealth.PlayerIsDead.AddListener(ResetTarget);   
    }

    private void ResetTarget()
    {
        _target = null;
    }

    public override void EnemyMovement()
    {
        if (_target != null)
        {
            var dir = (_target.transform.position - transform.position).normalized;
            _rb.velocity = dir * (Speed * Time.deltaTime);
        }
    }

    private IEnumerator DealDamageRoutine(Collision2D collision)
    {
        _isAttacking = true;
        while (collision.gameObject.CompareTag("Player") && Vector2.Distance(transform.position, collision.transform.position) <= 1f)
        {
            OnDealDamage.Invoke(Damage);
            yield return new WaitForSeconds(_attackCooldown);
        }
        _isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isAttacking)
        {
            StartCoroutine(DealDamageRoutine(collision));
        }
    }


}
