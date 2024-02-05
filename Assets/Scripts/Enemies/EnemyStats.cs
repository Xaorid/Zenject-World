using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Create New Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private int Health;
    [SerializeField] private int Damage;
    [SerializeField] private float Speed;

    public float GetSpeed => Speed;
    public int GetDamage => Damage;
    public int GetHealth => Health;
}
