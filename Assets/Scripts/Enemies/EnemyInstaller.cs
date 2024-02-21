using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private DynamitePool DynamitePoolPrefab;

    public override void InstallBindings()
    {
        BindDynamitePoolInstance();
    }

    private void BindDynamitePoolInstance()
    {
        DynamitePool dynamitePoolInstance = Container
            .InstantiatePrefabForComponent<DynamitePool>(DynamitePoolPrefab, transform.position, Quaternion.identity, null);

        Container
            .Bind<DynamitePool>()
            .FromInstance(dynamitePoolInstance)
            .AsSingle();
    }

}
