using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth Instance { get; set; }
    [Header("Health Settings")]
    public int maxHealth = 100;          // Maximum health of the enemy
    private int currentHealth;

    [Header("UI Elements")]
    public Image healthBarFill;          // Assign the Image UI component with "Filled" type in Inspector

    void Start()
    {
        currentHealth = maxHealth;
        //Enemy_Script.Instance.UpdateH();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

