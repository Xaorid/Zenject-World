using UnityEngine;
using UnityEngine.UI;

public class PlayerUIExp : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        PlayerLevel.UpdateExpOnUI.AddListener(UpdateExpValue);
        PlayerLevel.PlayerLevelUp.AddListener(ResetSliderParametres);
    }

    private void UpdateExpValue(float exp)
    {
        _slider.value = exp;
    }

    private void ResetSliderParametres(float exp)
    {
        _slider.value = 0;
        _slider.maxValue = exp;
    }
}
