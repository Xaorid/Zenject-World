using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _curHealth;
    [SerializeField] private int _maxHealth;
    private int _healthByVitality = 5;
    private PlayerStats _playerStats;

    public static UnityEvent PlayerIsDead = new();
    public static UnityEvent PlayerTakeDamage = new();
    public bool IsAlive { get; private set; } = true;

    public static UnityEvent<int, int> UpdateHealthOnUI = new();

    [Inject]
    private void Construct(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }

    private void Start()
    {     
        Enemy.OnDealDamage.AddListener(TakeDamage);
        SetPlayerHealth();
        UpdateHealthOnUI.Invoke(_curHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (IsAlive)
        {
            PlayerTakeDamage.Invoke();
            _curHealth -= damage;

            if (_curHealth <= 0)
            {
                _curHealth = 0;
                IsAlive = false;
                PlayerIsDead.Invoke();
            }

            UpdateHealthOnUI.Invoke(_curHealth, _maxHealth);
        }
    }

    private void SetPlayerHealth()
    {
        _maxHealth = _playerStats.Health;
        _curHealth = _maxHealth;
    }

    private void RecoveryHealth(int heal)
    {
        _curHealth += heal;
        if( _curHealth > _maxHealth)
        {
            _curHealth = _maxHealth;
        }
        UpdateHealthOnUI.Invoke(_curHealth, _maxHealth);
    }

    private void FullHeal()
    {
        _curHealth = _maxHealth;
    }

    private void IncreaseMaxHealth(int additionalHealth)
    {
        _maxHealth += additionalHealth;
        UpdateHealthOnUI.Invoke(_curHealth, _maxHealth);
    }

    public void IncreaseMaxHealthFromVit(int vit)
    {
        var bonusHealth = vit * _healthByVitality;
        IncreaseMaxHealth(bonusHealth);
        RecoveryHealth(bonusHealth);
    }
}
