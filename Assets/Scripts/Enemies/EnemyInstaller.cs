using System;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private Enemy _enemyPrefab;

    public override void InstallBindings()
    {
        BindEnemy();
    }

    private void BindEnemy()
    {
        Container.Bind<Player>().AsSingle();
        Container.Bind<Enemy>().FromInstance(_enemyPrefab).AsTransient();

    }
}
