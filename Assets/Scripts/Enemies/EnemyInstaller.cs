using System;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private EnemyMelee _enemyPrefab;

    public override void InstallBindings()
    {
        BindEnemy();
    }

    private void BindEnemy()
    {
        Container.Bind<Player>().AsSingle();
        Container.Bind<EnemyMelee>().FromInstance(_enemyPrefab).AsTransient();

    }
}
