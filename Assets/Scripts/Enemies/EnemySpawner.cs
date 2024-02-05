using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject]
    private DiContainer _container;

    [SerializeField] private Queue<Enemy> enemies = new();
    [SerializeField] private int _poolSize;

    [SerializeField] private Enemy _enemyPref;
    [SerializeField] private EnemyStats _enemyStats;

    [SerializeField] private float _difficultMultiplier = 1;

    private GameObject _parentObj;
 
    void Start()
    {
        InitializePool();      
        SpawnEnemyFromPool();
    }

    private void InitializePool()
    {
        _parentObj = new GameObject("Enemies");

        for (int i = 0; i < _poolSize; i++)
        {
            var newEnemy = _container.InstantiatePrefabForComponent<Enemy>
                (_enemyPref,transform.position,Quaternion.identity, _parentObj.transform);

            newEnemy.gameObject.SetActive(false);
            enemies.Enqueue(newEnemy);
        }
    }

    public Enemy SpawnEnemyFromPool()
    {
        if(enemies.Count > 0)
        {
            var enemyFromPool = enemies.Dequeue();
            SetNewEnemyStats(enemyFromPool);
            enemyFromPool.gameObject.SetActive(true);
            return enemyFromPool;
        }
        else
        {
            var newEnemy = _container.InstantiatePrefabForComponent<Enemy>(_enemyPref, transform.position, Quaternion.identity, _parentObj.transform);
            SetNewEnemyStats(newEnemy);
            return newEnemy;
        }
    }

    private void SetNewEnemyStats(Enemy enemy)
    {
        enemy.SetEnemyStats(
                _enemyStats.GetSpeed * _difficultMultiplier,
                (int)(_enemyStats.GetHealth * _difficultMultiplier),
                (int)(_enemyStats.GetDamage * _difficultMultiplier),
                1);
    }
}
