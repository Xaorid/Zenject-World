using UnityEngine;

public class PlayerStats
{
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public float AttackCooldown { get; private set; }
    public float Speed { get; private set; }
    public float SpeedMultiplier { get; private set; }
    public float Energy { get; private set; }
    public int Strength { get; private set; }
    public int Agility { get; private set; }
    public int Vitality { get; private set; }

    public PlayerStats(PlayerScriptableStats playerScriptableStats)
    {
        Health = playerScriptableStats.Health;
        Damage = playerScriptableStats.Damage;
        AttackCooldown = playerScriptableStats.AttackCooldown;
        Speed = playerScriptableStats.Speed;
        SpeedMultiplier = playerScriptableStats.SpeedMultiplier;
        Energy = playerScriptableStats.Energy;
        Strength = playerScriptableStats.Strength;
        Agility = playerScriptableStats.Agility;
        Vitality = playerScriptableStats.Vitality;
    }

}
