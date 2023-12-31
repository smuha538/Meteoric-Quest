using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject healthItem;
    public float dropProbability = 0.2f;
    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        Destroy(this.gameObject, 4f);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.collider.gameObject;
        if (otherObject.gameObject.layer == 7)
        {
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            if (healthItem != null && Random.value <= dropProbability)
            {
                Instantiate(healthItem, transform.position, Quaternion.identity);
            }
            if (scoreManager != null)
            {
                scoreManager.IncrementScore(2);
            }
        }
    }
}
