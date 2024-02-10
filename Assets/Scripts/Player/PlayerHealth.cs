using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _curHealth;
    [SerializeField] private int _maxHealth;

    private PlayerStats _playerStats;

    public static UnityEvent PlayerIsDead = new();
    public bool IsAlive { get; private set; } = true;

    [Inject]
    private void Construct(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }

    private void Start()
    {
        Enemy.OnDealDamage.AddListener(TakeDamage);
        SetPlayerHealth();
    }

    public void TakeDamage(int damage)
    {
        if (IsAlive)
        {
            _curHealth -= damage;
            if (_curHealth <= 0)
            {
                IsAlive = false;
                PlayerIsDead.Invoke();
            }
        }
    }

    private void SetPlayerHealth()
    {
        _maxHealth = _playerStats.Health;
        _curHealth = _maxHealth;
    }
}
