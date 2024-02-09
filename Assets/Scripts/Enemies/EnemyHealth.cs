using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyMelee _enemy;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _curHealth;

    private void Start()
    {
        _maxHealth = _enemy.MaxHealth;
        _curHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _curHealth -= damage;
        if(_curHealth <= 0)
        {
            Destroy(gameObject); //temporarily
        }
    }
}
