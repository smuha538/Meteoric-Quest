using System.Collections;
using UnityEngine;

public class AsteroidRing : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects = 10;
    public float spawnRadius = 5f;
    public float closingSpeed = 1f;
    public float gracePeriod = 1f;
    public float spawnInterval = 5f; 
    public float objectLifetime = 10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //StartCoroutine(GracePeriod());
    }
    private void OnEnable()
    {
        StartCoroutine(GracePeriod());
    }

    IEnumerator GracePeriod()
    {
        yield return new WaitForSeconds(gracePeriod);
        StartCoroutine(SpawnObjectsRepeatedly());
    }

    IEnumerator SpawnObjectsRepeatedly()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnObjects());
            yield return new WaitForSeconds(spawnInterval);
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

            Vector3 direction = (player.position - spawnedObject.transform.position).normalized;
            spawnedObject.GetComponent<Rigidbody2D>().velocity = direction * closingSpeed;

            Destroy(spawnedObject, objectLifetime);
        }

        yield return new WaitForSeconds(numberOfObjects * spawnInterval);
    }
}
