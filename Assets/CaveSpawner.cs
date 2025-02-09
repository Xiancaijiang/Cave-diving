using UnityEngine;

public class CaveSpawner : MonoBehaviour
{
    public GameObject cavePrefab;
    public float spawnDelay = 2f;
    public float minSpawnHeight = -2f;
    public float maxSpawnHeight = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnDelay);
    }

    private void SpawnPipe()
    {
        float randomHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
        Vector2 spawnPosition = new Vector2(transform.position.x, randomHeight);
        Instantiate(cavePrefab, spawnPosition, Quaternion.identity);
    }
}