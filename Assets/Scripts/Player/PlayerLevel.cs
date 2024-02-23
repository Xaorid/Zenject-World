using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private int _level = 1;
    [SerializeField] private float _curExp = 0;
    [SerializeField] private float _requiredExp = 100;
    [SerializeField] private int _skillPointCount;
    private int _skillPointFromLevel = 2;

    private float _stepRequiredExp = 0.45f;

    public static UnityEvent<float> UpdateExpOnUI = new();
    public static UnityEvent<float, int> PlayerLevelUp = new();
    public static UnityEvent<int> SkillPointOnUi = new();

    private void Start()
    {
        EnemyHealth.EnemyDead.AddListener(AddExp);
        PlayerSkillPointUI.OnRemoveSkillPoint.AddListener(RemoveSkillPoint);
        PlayerLevelUp.Invoke(_requiredExp, _level);
        SkillPointOnUi.Invoke(_skillPointCount);
    }

    private void IncreaseRequiredExp()
    {
        _requiredExp += (int)(_requiredExp * _stepRequiredExp);     
    }

    private void LevelUp()
    {
        _curExp = 0;
        _skillPointCount += _skillPointFromLevel;
        SkillPointOnUi.Invoke(_skillPointCount);
        _level++;
        IncreaseRequiredExp();
        PlayerLevelUp.Invoke(_requiredExp, _level);

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

    private void RemoveSkillPoint()
    {
        _skillPointCount--;
        SkillPointOnUi?.Invoke(_skillPointCount);
    }
}
