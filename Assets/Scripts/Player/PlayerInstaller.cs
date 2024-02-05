using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerScriptableStats PlayerStats;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Transform StartPos;
    public override void InstallBindings()
    {
        BindInputController();
        BindPlayerStats();
        BindPlayerInstance();
    }

    private void BindPlayerInstance()
    {
        Player playerInstance = Container
            .InstantiatePrefabForComponent<Player>(PlayerPrefab, StartPos.position, Quaternion.identity, null);

        Container
            .Bind<Player>()
            .FromInstance(playerInstance)
            .AsSingle();
    } 

    private void BindPlayerStats()
    {
        var playerStats = new PlayerStats(PlayerStats);
        Container
            .Bind<PlayerStats>()
            .FromInstance(playerStats)
            .AsSingle();
    }

    private void BindInputController()
    {
        var inputController = new InputController();
        Container
            .Bind<InputController>()
            .FromInstance(inputController)
            .AsSingle();
    }
}
