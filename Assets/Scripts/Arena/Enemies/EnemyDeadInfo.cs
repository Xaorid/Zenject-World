using UnityEngine;
public struct EnemyDeathInfo
{
    public Vector3 Position { get; set; }
    public float Experience { get; set; }

    public EnemyDeathInfo(Vector3 position, float experience)
    {
        Position = position;
        Experience = experience;
    }
}