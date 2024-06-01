using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _powerUpPrefab;
    private const float SPAWN_RANGE = 9.0f;
    private int _spawnCount = 1;
    private Queue<EnemyController> _enemyQueue;


    void Start()
    {
        _enemyQueue = new Queue<EnemyController>();
        SpawnEnemyWave(_spawnCount);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-SPAWN_RANGE, SPAWN_RANGE);
        float spawnPosZ = Random.Range(-SPAWN_RANGE, SPAWN_RANGE);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void SpawnEnemyWave(int numsOfEnemy)
    {
        for(int i = 0; i < numsOfEnemy; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            _enemyQueue.Enqueue(enemyController);
            enemyController.onDeath += OnEnemyDeath;
        }
        Instantiate(_powerUpPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }

    private void OnEnemyDeath()
    {
        _enemyQueue.Dequeue();
        if (_enemyQueue.Count <= 0)
        {
            _spawnCount++;
            SpawnEnemyWave(_spawnCount);
        }
    }
}
