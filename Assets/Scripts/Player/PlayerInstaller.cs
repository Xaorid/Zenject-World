using System;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerScriptableStats PlayerStats;
    [SerializeField] private PlayerBrains PlayerPrefab;
    [SerializeField] private Transform StartPos;
    public override void InstallBindings()
    {
        BindInputController();
        BindPlayerStats();
        BindPlayerInstance();
    }

    private void BindPlayerInstance()
    {
        PlayerBrains playerInstance = Container
            .InstantiatePrefabForComponent<PlayerBrains>(PlayerPrefab, StartPos.position, Quaternion.identity, null);
        BindAsSingle(playerInstance);
    }

    private void BindPlayerStats()
    {
        var playerStats = new PlayerStats(PlayerStats);
        BindAsSingle(playerStats);
    }

    private void BindInputController()
    {
        var inputController = new InputController();
        BindAsSingle(inputController);   
    }

    private void BindAsSingle<T>(T instance)
    {
        Container
        .Bind<T>()
            .FromInstance(instance)
            .AsSingle();
    }
}
