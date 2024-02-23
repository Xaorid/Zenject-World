using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIExp : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _levelText;

    private void Awake()
    {
        PlayerLevel.UpdateExpOnUI.AddListener(UpdateExpValue);
        PlayerLevel.PlayerLevelUp.AddListener(NewLevelValue);
    }

    private void UpdateExpValue(float exp)
    {
        _slider.value = exp;
    }

    private void NewLevelValue(float exp, int level)
    {
        _levelText.text = level.ToString();
        _slider.value = 0;
        _slider.maxValue = exp;
    }
}
