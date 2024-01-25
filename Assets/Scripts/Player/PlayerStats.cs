using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerScriptableStats _playerStats;
    [SerializeField] private int _health; 
    [SerializeField] private int _damage;
    [SerializeField] private float _speed; 
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _energy; 
    [SerializeField] private int _strength; 
    [SerializeField] private int _agility;
    [SerializeField] private int _vitality;
    public int GetHealth => _health;
    public int GetDamage => _damage;
    public float GetSpeed => _speed;
    public float GetSpeedMultiplier => _speedMultiplier;
    public float GetEnergy => _energy;
    public int GetStrength => _strength;
    public int GetAgility => _agility;
    public int GetVitality => _vitality;

    private void Start()
    {
        PlayerStatsInstall();
    }

    private void PlayerStatsInstall()
    {
        _health = _playerStats.Health;
        _damage = _playerStats.Damage;
        _speed = _playerStats.Speed;
        _speedMultiplier = _playerStats.SpeedMultiplier;
        _energy = _playerStats.Energy;
        _strength = _playerStats.Strength;
        _vitality = _playerStats.Vitality;
        _agility = _playerStats.Agility;
    }

}
