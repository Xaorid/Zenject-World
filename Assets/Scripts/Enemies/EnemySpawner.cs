using System.Collections;
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

    [Header("POOL CONFIG")]
    [SerializeField] private int _poolSize;

    [Header("ENEMY CONFIG")]
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private Enemy[] _enemyPref;

    private Queue<Enemy> enemies = new();
    private GameObject _parentObj;

    void Start()
    {
        InitializePool();
        StartCoroutine(TEST());
    }

    private void InitializePool()
    {     
        _parentObj = new GameObject("Enemies");

        for (int i = 0; i < _poolSize; i++)
        {
            var newEnemy = CreateNewEnemy();
            newEnemy.gameObject.SetActive(false);
            enemies.Enqueue(newEnemy);
        }
    }

    [ContextMenu("SpawnEnemyFromPool")]
    public Enemy SpawnEnemyFromPool()
    {
        if(enemies.Count > 0)
        {
            var enemyFromPool = enemies.Dequeue();
            SetNewStats(enemyFromPool);
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

    private Enemy CreateNewEnemy()
    {
        var enemy = _container.InstantiatePrefabForComponent<Enemy>
                (_enemyPref[Random.Range(0,_enemyPref.Length - 1)],
                RandomSpawnPos(),
                Quaternion.identity,
                _parentObj.transform,
                new object[]
                {
                    _enemyStats.GetSpeed * _difficultController.Difficult,
                    (int)(_enemyStats.GetHealth * _difficultController.Difficult),
                    (int)(_enemyStats.GetDamage * _difficultController.Difficult)
                });

        return enemy;
    }

    private void SetNewStats(Enemy enemy)
    {
        enemy.SetNewEnemyStats(
            _enemyStats.GetSpeed* _difficultController.Difficult,
                    (int)(_enemyStats.GetHealth * _difficultController.Difficult),
                    (int)(_enemyStats.GetDamage * _difficultController.Difficult)
                );
    }   


    private Vector3 RandomSpawnPos()
    {
        float x = Random.Range(0.05f, 0.95f);
        float y = Random.Range(0.05f, 0.95f);
        Vector3 pos = new Vector3(x, y, 0);
        pos = Camera.main.ViewportToWorldPoint(pos);
        pos.z = 0;
        return pos;
    }
    private IEnumerator TEST()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            SpawnEnemyFromPool();
        }
    }
}
