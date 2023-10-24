using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public int asteroidAmount;
    public List<GameObject> spawnPool;
    public GameObject quad;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Update()
    {
        spawnAsteroid();
    }
    public void spawnAsteroid()
    {
        destroyAsteroid();

        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider coordinates = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 position;

        if(GameObject.FindGameObjectsWithTag("SpawnableAsteroid").Length < asteroidAmount)
        {
            
                randomItem = Random.Range(0, spawnPool.Count);
                toSpawn = spawnPool[randomItem];
                screenX = Random.Range(coordinates.bounds.min.x, coordinates.bounds.max.x);
                screenY = Random.Range(coordinates.bounds.min.y, coordinates.bounds.max.y);
                position = new Vector2(screenX, screenY);
                GameObject asteroid = Instantiate(toSpawn, position, toSpawn.transform.rotation);
                Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();
                rigid.AddForce(Random.insideUnitCircle.normalized * Random.Range(0,100));

        }

    }

    private void destroyAsteroid()
    {
        foreach(GameObject singleObject in GameObject.FindGameObjectsWithTag("SpawnableAsteroid"))
        {
            MeshCollider coordinates = quad.GetComponent<MeshCollider>();
            Rigidbody2D objectRigid = singleObject.GetComponent<Rigidbody2D>();
            if (objectRigid.position.x < coordinates.bounds.min.x || objectRigid.position.x > coordinates.bounds.max.x || objectRigid.position.y < coordinates.bounds.min.y || objectRigid.position.y > coordinates.bounds.max.y)
            {
                Destroy(singleObject);
            }
        }
    }
}
