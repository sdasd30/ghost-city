using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory;

    void Awake()
    {
        inventory = new List<GameObject>();
    }

    public void AddToInventory(GameObject item)
    {
        item.GetComponent<InteractableItem>().enabled = false;

        inventory.Add(item);
    }
}
