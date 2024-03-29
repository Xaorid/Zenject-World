using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject]
    private DiContainer _container;

    [Header("COMPONENTS")]
    [SerializeField] private ParticlePool _particles;
    [SerializeField] private DifficultController _difficultController;
    [SerializeField] private WaveController _waveController;

    [Header("POOL CONFIG")]
    [SerializeField] private int _poolSize;

    [Header("ENEMY CONFIG")]
    [SerializeField] private Enemy[] _enemyPrefabs;

    [SerializeField] private List<Enemy> activeEnemies = new();
    private Queue<Enemy> enemies = new();
    
    private GameObject _parentObj;
    private Vector2 _leftBorderPos = new(8, 4.5f);
    private Vector2 _rightBorderPos = new(-8, -8.5f);

    void Awake()
    {
        _parentObj = new GameObject("Enemies");
    }

    private void Start()
    {
        WaveController.WaveEnd.AddListener(ReturnAllEnemiesToPool);
        InitializePool();
    }

    private void InitializePool()
    {     
        for (int i = 0; i < _poolSize; i++)
        {
            var newEnemy = CreateNewEnemy();
            newEnemy.gameObject.SetActive(false);
            enemies.Enqueue(newEnemy);
        }
    }

    public Enemy SpawnEnemyFromPool()
    {
        Enemy enemy;

        if (enemies.Count > 0)
        {
            enemy = enemies.Dequeue();
        }

        else
        {
            enemy = CreateNewEnemy();
            
        }

        SetNewStats(enemy);
        enemy.transform.position = RandomSpawnPos();
        enemy.gameObject.SetActive(true);
        _particles.SpawnParticleFromPool(enemy.transform.position);
        activeEnemies.Add(enemy);
        return enemy;
    }

    public void ReturnToPool(Enemy enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemy.gameObject.SetActive(false);
            activeEnemies.Remove(enemy);
            enemy.transform.position = Vector3.zero;
            enemy.StopAllCoroutines();
            enemies.Enqueue(enemy);
        }
    }

    private Enemy CreateNewEnemy()
    {
        var enemy = _container.InstantiatePrefabForComponent<Enemy>
                (_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)],
                RandomSpawnPos(),
                Quaternion.identity,
                _parentObj.transform);
        SetNewStats(enemy);
        enemy.OnSpawnFromPool(this);

        return enemy;
    }

    private void SetNewStats(Enemy enemy)
    {
        var enemyStats = enemy.EnemyStats;

        enemy.SetNewEnemyStats(
                enemyStats.GetSpeed,
                (int)(enemyStats.GetHealth * _difficultController.Difficult + _waveController.CurWave),
                (int)(enemyStats.GetDamage * _difficultController.Difficult),
                enemyStats.GetExp * _waveController.CurWave
                );
    }   

    private Vector3 RandomSpawnPos()
    {
        var posX = Random.Range(_leftBorderPos.x, _rightBorderPos.x);
        var posY = Random.Range(_leftBorderPos.y, _rightBorderPos.y);
        var pos = new Vector3(posX, posY, 0);
        return pos;
    }

    private void ReturnAllEnemiesToPool()
    {
        while(activeEnemies.Count > 0)
        {
            ReturnToPool(activeEnemies[0]);
        }
    }
}
