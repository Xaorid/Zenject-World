using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PlayerCore : MonoInstaller
{
    protected InputController _controls;
    [SerializeField] private PlayerScriptableStats _stats;

    private void Awake()
    {
        _controls = new InputController();                    
    }

    public override void InstallBindings()
    {
        BindPlayerStats();
        BindInputController();
    }

    private void BindPlayerStats()
    {
        var playerStats = new PlayerStats(_stats);
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
