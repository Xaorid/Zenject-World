using UnityEngine;

[CreateAssetMenu(fileName ="New Player Stats", menuName ="Create New Stats")]
public class PlayerScriptableStats : ScriptableObject
{
    [Header("Movement Parameters")]
    public float Speed;
    public float SpeedMultiplier;
    public float Energy;

    [Header("Battle Parameters")]
    public int Health;
    public int Damage;

    [Header("Core Player Stats")]
    public int Vitality;
    public int Agility;
    public int Strength;

}
