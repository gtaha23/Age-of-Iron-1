using System.Collections;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject unitPrefab;         // Assign your enemy prefab
    public int maxUnits = 5;            // Desired maximum alive enemies at any time
    public float spawnDelay = 1.5f;        // Delay (seconds) between spawn attempts
    public Vector3 spawnAreaSize = new Vector3(15, 5, 15); // Spawn area size

    void Start()
    {
        if (unitPrefab == null)
        {
            Debug.LogError("EnemySpawner: enemyPrefab is not assigned.");
            return;
        }
        StartCoroutine(SpawnEnemiesControl());
    }

    private IEnumerator SpawnEnemiesControl()
    {
        int currentCount = CountAliveEnemies();

        if (currentCount < maxUnits)
        {
            Vector3 spawnPos = GetRandomSpawnPosition();
            Instantiate(unitPrefab, spawnPos, Quaternion.identity);
            Debug.Log($"EnemySpawner: Spawned enemy #{currentCount + 1} at {spawnPos}");
        }
        else
        {
            Debug.Log($"EnemySpawner: Max enemies reached ({currentCount}/{maxUnits}). Waiting...");
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

