using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaveController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    private float _spawnDelay = 1.5f;
    private float _stepSpawnDelay = 0.05f;

    public int CurWave { get; private set; } = 1;
    private float _waveDuration = 20f;
    private bool _waveIsRunning = true;

    public static UnityEvent<int> OnNewWave = new();
    public static UnityEvent<float> OnWaveTimeUpdated = new();

    private void Start()
    {
        StartNewWave();   
    }

    private IEnumerator SpawnRoutine(float delay)
    {
        StartCoroutine(WaveTimerRoutine(_waveDuration));

        while (_waveIsRunning)
        {
            _enemySpawner.SpawnEnemyFromPool();
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator WaveTimerRoutine(float duration)
    {
        float timeLeft = duration;
        while (timeLeft >= 0)
        {
            OnWaveTimeUpdated.Invoke(timeLeft);
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }
        EndWave();
        yield return new WaitForSeconds(duration / 3f);
        IncreaseWaveDuration();
        IncreaseSpawnRate();
        StartNewWave();
    }

    private void EndWave()
    {
        _waveIsRunning = false;
        CurWave++;
    }

    public void StartNewWave()
    {
        OnNewWave.Invoke(CurWave);
        _waveIsRunning = true;
        StartCoroutine(SpawnRoutine(_spawnDelay));
    }

    private void IncreaseWaveDuration()
    {
        _waveDuration += 5f;
    }
    private void IncreaseSpawnRate()
    {
        _spawnDelay -= _stepSpawnDelay;
    }
}
