using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 10f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
          EndGame();       
        }
    }

    public void IncreaseHealth(int healAmount)
    {
        currentHealth += healAmount; 
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnableAsteroid") || collision.gameObject.CompareTag("EnemyAttack"))
        {
            TakeDamage(1);
            healthBar.fillAmount = currentHealth / maxHealth;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealthItem"))
        {
            IncreaseHealth(1);
            healthBar.fillAmount = currentHealth / maxHealth;
            Destroy(collision.gameObject);
        }
    }
}