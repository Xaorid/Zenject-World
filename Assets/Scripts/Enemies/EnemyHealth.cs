using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private Enemy _enemy;
    private int _curHealth;

    [HideInInspector]
    public UnityEvent EnemyOnTakeDamage = new();

    public static UnityEvent<EnemyDeathInfo> EnemyDead = new();

    public void TakeDamage(int damage)
    {
        EnemyOnTakeDamage.Invoke();
        _curHealth -= damage;
        if(_curHealth <= 0)
        {
            var enemyDeadInfo = new EnemyDeathInfo(
                    transform.position,
                    _enemy.Exp
                );

            EnemyDead.Invoke(enemyDeadInfo);
            _enemy.ReturnToPool();
        }
    }

    private void ResetHealth()
    {
        _curHealth = _enemy.MaxHealth;
    }

    private void OnEnable()
    {
        ResetHealth();
    }
}
