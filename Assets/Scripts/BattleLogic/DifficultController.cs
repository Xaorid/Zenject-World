using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : MonoBehaviour
{
    public float Difficult { get; private set; } = 1f;
    private float _stepToUp = 0.1f;

    private void Start()
    {
        SetStartDifficult();
        WaveController.OnNewWave.AddListener(UpDifficult);
    }

    private void UpDifficult(int wave)
    {
        Difficult += _stepToUp * wave;
    }
    private void SetStartDifficult()
    {
        Difficult = 1f;
    }
}
