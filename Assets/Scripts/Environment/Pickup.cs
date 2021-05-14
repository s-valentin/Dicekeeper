using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public Item item;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CheckIfInventoryHasOpenSlots())
            if (collision.CompareTag("Player"))
            {
                inventory.AddItem(item);
                Destroy(gameObject);
            }
        }

    public bool CheckIfInventoryHasOpenSlots()
    {
        
        for (int i = 0; i < inventory.inventorySlots.Count; i++)
        {
            if (inventory.inventorySlots[i].item == null)
            {
                return true;
            }
        }
        return false;
    }

}

    
