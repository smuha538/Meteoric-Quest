using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 3;
    public float spawnInterval = 2f;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SpawnEnemiesWithInterval());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(SpawnEnemiesWithInterval());
            DespawnEnemies();
        }
    }

    private IEnumerator SpawnEnemiesWithInterval()
    {
        while (spawnedEnemies.Count < maxEnemies)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            spawnedEnemies.Add(enemy);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;
        bool validPosition = false;
        const float minDistance = 2f;
        while (!validPosition)
        {
            spawnPosition = transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);

            validPosition = true;
            foreach (GameObject enemy in spawnedEnemies)
            {
                if (Vector3.Distance(spawnPosition, enemy.transform.position) < minDistance)
                {
                    validPosition = false;
                    break;
                }
            }
        }

        return spawnPosition;
    }

    private void DespawnEnemies()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            Destroy(enemy);
        }
        Debug.Log(spawnedEnemies.Count);

        spawnedEnemies.Clear();
    }
}
