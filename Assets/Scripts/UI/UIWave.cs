using TMPro;
using UnityEngine;

public class UIWave : MonoBehaviour
{
    [SerializeField] private TMP_Text _curWaveText;
    [SerializeField] private TMP_Text _waveTimerText;

    private void Awake()
    {
        WaveController.OnNewWave.AddListener(UpdateCurWaveText);
        WaveController.OnWaveTimeUpdated.AddListener(UpdateWaveTimerText);
    }

    private void UpdateCurWaveText(int curWave)
    {
        _curWaveText.text = curWave.ToString() + " Wave";
    }

    private void UpdateWaveTimerText(float timeLeft)
    {
        _waveTimerText.text = timeLeft.ToString("0");
    }
}
