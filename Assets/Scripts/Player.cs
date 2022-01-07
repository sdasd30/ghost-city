/*
 * Author: Isaac, Richard
 * Description: Contains general info and methods related to the player
 */

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 spawnPoint;

    public List<GameObject> inventory;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    float tick = 0;

    bool invincible = false;

    // CHANGE THIS IF BUTTON USED FOR INTERACTION CHANGES OR EVERYTHING WILL BE WRONG
    public string interactButton = "F";

    void Awake()
    {
        inventory = new List<GameObject>();

        spawnPoint = transform.position;
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

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

    public void AddToInventory(GameObject item)
    {
        item.GetComponent<InteractableItem>().enabled = false;

        inventory.Add(item);
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
    }

    //Function that lowers player's health
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!invincible && collider.CompareTag("Enemy"))
        {
            TakeDamage(collider.GetComponent<Enemy>().damage);

            if (currentHealth <= 0)
            {
                currentHealth = maxHealth;
                healthBar.SetMaxHealth(maxHealth);

                Respawn();
            }

            invincible = true;

            tick = 0.5f;
        }
    }
}
