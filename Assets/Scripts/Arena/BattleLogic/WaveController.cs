using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaveController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    private float _spawnDelay = 1.5f;
    private float _stepSpawnDelay = 0.05f;
    private float _betweenWaveDelay = 5f;
    private bool _canSpawn = true;

    public int CurWave { get; private set; }
    private float _waveDuration = 15f;
    private float _waveDurationIncrease = 5f;
    private bool _waveIsRunning = true;

    public static UnityEvent<int> OnNewWave = new();
    public static UnityEvent<float> OnWaveTimeUpdated = new();
    public static UnityEvent WaveEnd = new();
    public static UnityEvent OnGetReadyWave = new();

    private void Start()
    {
        PlayerHealth.PlayerIsDead.AddListener(ForcedWaveEnd);
        StartCoroutine(DurationBetweenWaveRoutine(_betweenWaveDelay));
    }

    private IEnumerator SpawnRoutine(float delay)
    {
        StartCoroutine(WaveTimerRoutine(_waveDuration));

        while (_waveIsRunning && _canSpawn)
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
        IncreaseWaveDuration();
        IncreaseSpawnRate();
    }

    private void EndWave()
    {
        StopAllCoroutines();
        _waveIsRunning = false;
        WaveEnd.Invoke();
    }

    private void StartNewWave()
    {
        CurWave++;
        OnNewWave.Invoke(CurWave);
        _waveIsRunning = true;      
        for(int i = CurWave / 5; i >= 0; i--)
        {
            StartCoroutine(SpawnRoutine(_spawnDelay));
        }
    }

    private void IncreaseWaveDuration()
    {
        _waveDuration += _waveDurationIncrease;
    }
    private void IncreaseSpawnRate()
    {
        _spawnDelay -= _stepSpawnDelay;
    }

    public void NextWave()
    {
        StartCoroutine(DurationBetweenWaveRoutine(_betweenWaveDelay));
    }

    private IEnumerator DurationBetweenWaveRoutine(float duration)
    {
        if(_canSpawn)
        {
            OnGetReadyWave.Invoke();
            float timeLeft = duration;
            while (timeLeft >= 0)
            {
                OnWaveTimeUpdated.Invoke(timeLeft);
                yield return new WaitForSeconds(1f);
                timeLeft--;
            }

            StartNewWave();
        }  
    }

    private void ForcedWaveEnd()
    {
        _canSpawn = false;
        WaveEnd.Invoke();
    }
}
