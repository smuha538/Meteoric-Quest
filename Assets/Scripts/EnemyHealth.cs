using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;

    public GameObject healthItem;
    public float dropProbability = 0.2f;
    private ScoreManager scoreManager;


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            if (healthItem != null && Random.value <= dropProbability)
            {
                Instantiate(healthItem, transform.position, Quaternion.identity);
            }
            if (scoreManager != null)
            {
                scoreManager.IncrementScore(6);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnableAsteroid") || collision.gameObject.CompareTag("ShipAttack"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }


}
