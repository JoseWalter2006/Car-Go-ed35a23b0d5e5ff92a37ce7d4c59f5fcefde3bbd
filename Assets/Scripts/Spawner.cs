using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnRate = 2f; // cada cuánto aparece
    float timer;

    public float leftLimit = -6.24f;
    public float rightLimit = 5.45f;

    public float spawnY = 8f; // arriba de la pantalla

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(leftLimit, rightLimit);

        Vector2 spawnPos = new Vector2(randomX, spawnY);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}