using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<GameObject> enemies; // List to hold enemy prefabs
    public Transform spawnZone; // Parent object defining spawn area
    public float spawnIntervalMin = 2f;
    public float spawnIntervalMax = 5f;
    
    public List<GameObject> decor; // List to hold enemy prefabs
    public Transform decorSpawnZone; // Parent object defining spawn area
    public float decorSpawnIntervalMin = 0.5f;
    public float decorSpawnIntervalMax = 2f;
    
    private float minX, maxX, spawnY;
    
    private float decorMinX, decorMaxX, decorSpawnY;

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
        
        
        if (decor.Count == 0 || decorSpawnZone == null)
        {
            Debug.LogError("Enemies list is empty or SpawnZone is not assigned!");
            return;
        }

        // Determine spawn zone boundaries
        Collider2D decorZoneCollider = decorSpawnZone.GetComponent<Collider2D>();
        if (decorZoneCollider == null)
        {
            Debug.LogError("DecorSpawnZone needs a Collider2D!");
            return;
        }

        decorMinX = decorZoneCollider.bounds.min.x;
        decorMaxX = decorZoneCollider.bounds.max.x;
        decorSpawnY = decorZoneCollider.bounds.center.y; // Enemies spawn at zone's center Y

        StartCoroutine(SpawnDecors());
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
        if (decor.Count == 0) return;
        
        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), spawnY);
        GameObject enemyPrefab = enemies[Random.Range(0, enemies.Count)];
        Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(180, 0, 0));
    }
    
    IEnumerator SpawnDecors()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(decorSpawnIntervalMin, decorSpawnIntervalMax));
            SpawnDecor();
        }
    }

    void SpawnDecor()
    {
        if (decor.Count == 0) return;
        
        Vector2 decorSpawnPosition = new Vector2(Random.Range(decorMinX, decorMaxX), decorSpawnY);
        GameObject decorPrefab = decor[Random.Range(0, decor.Count)];
        Instantiate(decorPrefab, decorSpawnPosition, Quaternion.identity);
    }
}