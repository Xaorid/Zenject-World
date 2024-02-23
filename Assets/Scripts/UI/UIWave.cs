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
        WaveController.OnGetReadyWave.AddListener(UpdateGetReady);
    }

    private void UpdateCurWaveText(int curWave)
    {
        _curWaveText.text = curWave.ToString() + " Wave";
    }

    private void UpdateWaveTimerText(float timeLeft)
    {
        _waveTimerText.text = timeLeft.ToString("0");
    }

    private void UpdateGetReady()
    {
        _curWaveText.text = "Get Ready!";
    }
}
