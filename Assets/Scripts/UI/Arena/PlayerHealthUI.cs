using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    private void Start()
    {
        PlayerHealth.UpdateHealthOnUI.AddListener(UpdateHealthBar);
    }

    private void UpdateHealthBar(int curHealth, int maxHealth)
    {
        _healthText.text = "Health: " + curHealth.ToString() + "/" + maxHealth.ToString();
    }
}
