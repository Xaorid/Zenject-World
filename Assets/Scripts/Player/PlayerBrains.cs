using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerBrains : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAttack _playerAttack;

    private Parameters parameters;
    public struct Parameters
    {
        public int Agility;
        public int Vitality;
        public int Strength;
    }

    public delegate void OnParameterChangedDelegate(Parameters parameter);
    public static event OnParameterChangedDelegate OnParametersChanged;

    public int Vitality
    {
        get { return parameters.Vitality; }
        set
        {
            if (parameters.Vitality != value)
            {
                var variance = value - parameters.Vitality;
                parameters.Vitality = value;
                OnParametersChanged?.Invoke(parameters);
                _playerHealth.IncreaseMaxHealthFromVit(variance);
            }
        }
    }
    public int Agility
    {
        get { return parameters.Agility; }
        set
        {
            if (parameters.Agility != value)
            {
                var variance = value - parameters.Agility;
                parameters.Agility = value;
                OnParametersChanged?.Invoke(parameters);
                _playerMovement.IncreaseSpeedFromAgility(variance);
                _playerAttack.IncreaseAttackSpeedFromAgility(variance);
            }
        }
    }
    public int Strength
    {
        get { return parameters.Strength; }
        set
        {
            if (parameters.Strength != value)
            {
                var variance = value - parameters.Strength;
                parameters.Strength = value;
                OnParametersChanged?.Invoke(parameters);
                _playerAttack.IncreaseDamageFromStrength(variance);
            }
        }
    }

    private PlayerStats _playerStats;

    [Inject]
    private void Construct(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }

    private void Start()
    {
        SetPlayerStats(_playerStats);
        PlayerSkillPointUI.OnSkillUp.AddListener(IncreaseParametår);
    }

    private void SetPlayerStats(PlayerStats playerStats)
    {
        Vitality = playerStats.Vitality;
        Agility = playerStats.Agility;
        Strength = playerStats.Strength;
    }

    private void IncreaseParametår(string parameter)
    {
        switch(parameter)
        {
            case "Vitality":
                Vitality++;
                break;

            case "Agility":
                Agility++;
                break;

            case "Strength":
                Strength++;
                break;

        }
    }
}
