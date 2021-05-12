using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingItems : MonoBehaviour
{
    public Inventory inventory;
    public ShopInventory shopInventory;
    public Item item;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        shopInventory = GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopInventory.AddItem(item);
            // Not working
            /*inventory.RemoveItem(item);
            */
        }
    }
}
