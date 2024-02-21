using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private int _level = 1;
    [SerializeField] private float _curExp = 0;
    [SerializeField] private float _requiredExp = 100;

    private float _stepRequiredExp = 0.45f;

    public static UnityEvent<float> UpdateExpOnUI = new();
    public static UnityEvent<float> PlayerLevelUp = new();

    private void Start()
    {
        EnemyHealth.EnemyDead.AddListener(AddExp);
        PlayerLevelUp.Invoke(_requiredExp);
    }

    private void IncreaseRequiredExp()
    {
        _requiredExp += (int)(_requiredExp * _stepRequiredExp);     
    }

    private void LevelUp()
    {
        _curExp = 0;
        _level++;
        IncreaseRequiredExp();
        PlayerLevelUp.Invoke(_requiredExp);
    }

    private void AddExp(EnemyDeathInfo enemyInfo)
    {
        _curExp += enemyInfo.Experience;
        UpdateExpOnUI.Invoke(_curExp);

        if (_curExp >= _requiredExp)
        {
            LevelUp();
        }
    }
}
