using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCurrentStatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _expText;
    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _atkSpeedText;

    private void Start()
    {
        PlayerLevel.AllStatsOnUI.AddListener(UpdateLevelExpText);
        PlayerAttack.DamageOnUI.AddListener(UpdateAttackText);
    }

    private void UpdateLevelExpText(float exp, float reqExp, int level)
    {
        _levelText.text = $"Level: {level}";
        _expText.text = $"Exp: {exp}/{reqExp}";
    }

    private void UpdateAttackText(int damage, float atkCooldown)
    {
        _damageText.text = $"Damage: {damage}";
        _atkSpeedText.text = $"Attack Cooldown: {atkCooldown}s";
    }
}
