using UnityEngine;

public class PlayerStats
{
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

    public PlayerStats(PlayerScriptableStats playerScriptableStats)
    {
        _health = playerScriptableStats.Health;
        _damage = playerScriptableStats.Damage;
        _speed = playerScriptableStats.Speed;
        _speedMultiplier = playerScriptableStats.SpeedMultiplier;
        _energy = playerScriptableStats.Energy;
        _strength = playerScriptableStats.Strength;
        _vitality = playerScriptableStats.Vitality;
        _agility = playerScriptableStats.Agility;
    }

}
