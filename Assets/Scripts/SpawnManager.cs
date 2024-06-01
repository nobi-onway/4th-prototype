using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private const float SPAWN_RANGE = 9.0f;

    private const float SPAWN_DELAY = 1.5f;
    private const float SPAWN_INTERVAL = 3.0f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), SPAWN_DELAY, SPAWN_INTERVAL);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-SPAWN_RANGE, SPAWN_RANGE);
        float spawnPosZ = Random.Range(-SPAWN_RANGE, SPAWN_RANGE);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }
}
