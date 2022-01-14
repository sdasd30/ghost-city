/*
 * Author: Isaac
 * Description: Base class for interactable items
 */

using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    GameObject prompt;

    void Start()
    {
        prompt = transform.GetChild(0).gameObject;

        prompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && prompt.activeInHierarchy)
        {
            GameObject.Find("Player").GetComponent<Inventory>().AddToInventory(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.SetActive(false);
        }
    }
}
