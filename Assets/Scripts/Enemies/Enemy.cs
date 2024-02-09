using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Enemy : MonoBehaviour
{
    public abstract float Speed { get; protected set; }
    public abstract int MaxHealth { get; protected set; }
    public abstract int Damage { get; protected set; }

    public abstract void EnemyMovement();
    public abstract void SetNewEnemyStats(float speed, int health, int damage);
}
