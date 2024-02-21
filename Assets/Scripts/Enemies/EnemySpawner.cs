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
    [SerializeField] private Enemy[] _enemyPref;

    private Queue<Enemy> enemies = new();



    private int healthForWave;
    private int damageForWave;




    private GameObject _parentObj;
    private Vector2 _leftBorderPos = new(8, 4.5f);
    private Vector2 _rightBorderPos = new(-8, -8.5f);

    void Awake()
    {
        _parentObj = new GameObject("Enemies");
    }

    private void Start()
    {
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
        if(enemies.Count > 0)
        {
            var enemyFromPool = enemies.Dequeue();
            SetNewStats(enemyFromPool);
            enemyFromPool.transform.position = RandomSpawnPos();
            enemyFromPool.gameObject.SetActive(true);
            _particles.SpawnParticleFromPool(enemyFromPool.transform.position);
            return enemyFromPool;
        }
        else
        {
            var newEnemy = CreateNewEnemy();
            _particles.SpawnParticleFromPool(newEnemy.transform.position);
            return newEnemy;
        }
    }

    public void ReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemies.Enqueue(enemy);
    }

    private Enemy CreateNewEnemy()
    {
        var enemy = _container.InstantiatePrefabForComponent<Enemy>
                (_enemyPref[Random.Range(0, _enemyPref.Length)],
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
                (int)(enemyStats.GetHealth * _difficultController.Difficult + _waveController.CurWave * healthForWave),
                (int)(enemyStats.GetDamage * _difficultController.Difficult + _waveController.CurWave * damageForWave),
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
}
