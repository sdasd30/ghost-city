/* 
 * Author: Richard
 * Description: Controls what hurts the player and how much damage the hurt deals
*/


using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform Player;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    //Function that lowers player's health
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

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


        //Not working
        void OnTriggerEnter(Collider2D coll)

        {
            if (coll.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(1);
                Player.transform.position = respawnPoint.transform.position;

            }
        }



        //If Health = 0, player dies
        if (currentHealth <= 0)
        {
            Player.transform.position = respawnPoint.transform.position;
            currentHealth = 100;

        }
    }


}
