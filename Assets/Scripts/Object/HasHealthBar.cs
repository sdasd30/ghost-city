using UnityEngine;

[RequireComponent(typeof(SpawnableObject))]
public class HasHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Awake()
    {
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;

            GetComponent<SpawnableObject>().HandleDeath();
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
