using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private Enemy _enemy;
    private int _curHealth;

    [HideInInspector]
    public UnityEvent EnemyOnTakeDamage = new();

    public static UnityEvent<Vector3> EnemyOnDead = new();

    public void TakeDamage(int damage)
    {
        EnemyOnTakeDamage.Invoke();
        _curHealth -= damage;
        if(_curHealth <= 0)
        {
            EnemyOnDead.Invoke(transform.position);
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
