using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies; // List to hold enemy prefabs
    public Transform spawnZone; // Parent object defining spawn area
    public float spawnIntervalMin = 2f;
    public float spawnIntervalMax = 5f;
    
    private float minX, maxX, spawnY;

    void Start()
    {
        if (enemies.Count == 0 || spawnZone == null)
        {
            Debug.LogError("Enemies list is empty or SpawnZone is not assigned!");
            return;
        }

        // Determine spawn zone boundaries
        Collider2D zoneCollider = spawnZone.GetComponent<Collider2D>();
        if (zoneCollider == null)
        {
            Debug.LogError("SpawnZone needs a Collider2D!");
            return;
        }

        minX = zoneCollider.bounds.min.x;
        maxX = zoneCollider.bounds.max.x;
        spawnY = zoneCollider.bounds.center.y; // Enemies spawn at zone's center Y

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemies.Count == 0) return;
        
        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), spawnY);
        GameObject enemyPrefab = enemies[Random.Range(0, enemies.Count)];
        Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(180, 0, 0));
    }
}