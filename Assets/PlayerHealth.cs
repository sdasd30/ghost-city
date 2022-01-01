/* 
 * Author: Richard
 * Description: Controls what hurts the player and how much damage the hurt deals
*/


using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {

        //Going to change depending on what hurts the game object

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
