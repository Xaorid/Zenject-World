using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    private bool waveIsRunning = false;



    private IEnumerator SpawnRoutine(float delay)
    {
        while (waveIsRunning)
        {
            _enemySpawner.SpawnEnemyFromPool();
            yield return new WaitForSeconds(delay);
        }
    }
}
