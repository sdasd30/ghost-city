/*
 * Author: Isaac, Richard
 * Description: Contains general info and methods related to the player
 */

using UnityEngine;

[RequireComponent(typeof(Inventory), typeof(HasHealthBar))]
public class Player : MonoBehaviour
{
    float tick = 0;

    bool invincible = false;

    // CHANGE THIS IF BUTTON USED FOR INTERACTION CHANGES OR EVERYTHING WILL BE WRONG
    public string interactButton = "F";

    void Update()
    {
        if (tick > 0)
        {
            tick -= Time.deltaTime;
        }

        else
        {
            invincible = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!invincible && collider.CompareTag("Enemy"))
        {
            GetComponent<HasHealthBar>().TakeDamage(collider.GetComponent<Enemy>().damage);

            invincible = true;

            tick = 0.5f;
        }
    }
}
