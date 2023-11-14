using System.Collections;
using UnityEngine;

public class AsteroidLockon : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects = 10;
    public float spawnRadius = 5f;
    public float followingSpeed = 1f;
    public float gracePeriod = 1f;
    public float spawnInterval = 1f; // Set the interval for each object spawn in seconds
    public float completeCycleInterval = 5f; // Set the interval between complete cycles in seconds

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(GracePeriod());
    }

    IEnumerator GracePeriod()
    {
        yield return new WaitForSeconds(gracePeriod);
        StartCoroutine(SpawnObjectsRepeatedly());
    }

    IEnumerator SpawnObjectsRepeatedly()
    {
        while (true) // Run indefinitely
        {
            yield return StartCoroutine(SpawnObjects());
            yield return new WaitForSeconds(completeCycleInterval);
        }
    }

    IEnumerator SpawnObjects()
    {
        float angleStep = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * angleStep;
            float spawnX = player.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius;
            float spawnY = player.position.y + Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius;

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
            Quaternion spawnRotation = Quaternion.identity;

            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);

            // Start a coroutine to make the object follow the player
            StartCoroutine(MoveObjectTowardsPlayer(spawnedObject));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator MoveObjectTowardsPlayer(GameObject obj)
    {
        while (obj != null && obj.activeSelf) // Check if the object is still active
        {
            Vector3 direction = (player.position - obj.transform.position).normalized;
            obj.GetComponent<Rigidbody2D>().velocity = direction * followingSpeed;

            yield return null; // Allow the frame to update
        }
    }
}
