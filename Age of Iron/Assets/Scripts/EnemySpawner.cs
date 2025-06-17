using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;         // Assign your enemy prefab
    public int maxEnemies = 10;            // Desired maximum alive enemies at any time
    public float spawnDelay = 1.0f;        // Delay (seconds) between spawn attempts
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // Spawn area size

    void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("EnemySpawner: enemyPrefab is not assigned.");
            return;
        }
        StartCoroutine(SpawnEnemiesControl());
    }

    private IEnumerator SpawnEnemiesControl()
    {
        int currentCount = CountAliveEnemies();

        if (currentCount < maxEnemies)
        {
            Vector3 spawnPos = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            Debug.Log($"EnemySpawner: Spawned enemy #{currentCount + 1} at {spawnPos}");
        }
        else
        {
            Debug.Log($"EnemySpawner: Max enemies reached ({currentCount}/{maxEnemies}). Waiting...");
        }

        yield return new WaitForSeconds(spawnDelay);
    }

    private int CountAliveEnemies()
    {
        // Count active Enemy_Script instances in the scene
        Enemy_Script[] enemies = FindObjectsOfType<Enemy_Script>();
        return enemies.Length;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = transform.position.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float y = transform.position.y + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);
        float z = transform.position.z + Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f);
        return new Vector3(x, y, z);
    }
}

