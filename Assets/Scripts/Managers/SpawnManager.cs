using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public Transform spawnZone;
    public float spawnIntervalMin = 2f;
    public float spawnIntervalMax = 5f;

    public List<GameObject> decor;
    public Transform decorSpawnZone;
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

        Collider2D zoneCollider = spawnZone.GetComponent<Collider2D>();
        if (zoneCollider == null)
        {
            Debug.LogError("SpawnZone needs a Collider2D!");
            return;
        }

        minX = zoneCollider.bounds.min.x;
        maxX = zoneCollider.bounds.max.x;
        spawnY = zoneCollider.bounds.center.y;

        StartCoroutine(SpawnEnemies());

        if (decor.Count == 0 || decorSpawnZone == null)
        {
            Debug.LogError("Decor list is empty or DecorSpawnZone is not assigned!");
            return;
        }

        Collider2D decorZoneCollider = decorSpawnZone.GetComponent<Collider2D>();
        if (decorZoneCollider == null)
        {
            Debug.LogError("DecorSpawnZone needs a Collider2D!");
            return;
        }

        decorMinX = decorZoneCollider.bounds.min.x;
        decorMaxX = decorZoneCollider.bounds.max.x;
        decorSpawnY = decorZoneCollider.bounds.center.y;

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
        if (enemies.Count == 0) return;

        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), spawnY);
        GameObject enemyPrefab = enemies[Random.Range(0, enemies.Count)];
        Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(180, 0, 0));

        // Notify ScoreManager that an enemy has spawned
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.RegisterSpawn();
        }
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
        GameObject decorInstance = Instantiate(decorPrefab, decorSpawnPosition, Quaternion.identity);

        // Ensure decor is behind everything by adjusting sorting order
        SpriteRenderer decorRenderer = decorInstance.GetComponent<SpriteRenderer>();
        if (decorRenderer != null)
        {
            decorRenderer.sortingOrder = -10;
        }
    }
}
