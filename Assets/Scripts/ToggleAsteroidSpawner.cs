using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidSpawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {  
            if (asteroidSpawner.activeSelf == false)
            {
                asteroidSpawner.SetActive(true);
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (asteroidSpawner.activeSelf == true)
            {
                asteroidSpawner.SetActive(false);
            }
            GameObject[] gos = GameObject.FindGameObjectsWithTag("SpawnableAsteroid");
            foreach (GameObject go in gos)
            {
                Destroy(go);
            }
        }
        

    }
}
