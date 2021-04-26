using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Item[] itemList = new Item[9];
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    private bool Add(Item item)
    {
        for(int i = 0; i < itemList.Length; i++)
        {
            if(itemList[i] == null)
            {
                itemList[i] = item;
                inventorySlots[i].item = item;
                return true;
            }
        }
        return false;
    }

    public void UpdateSlotUI()
    {
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot();
        }
    }

    public void AddItem(Item item)
    {
        bool hasAdded = Add(item);

        if (hasAdded)
        {
            UpdateSlotUI();
        }
    }

    // Not working!
    /*private bool Remove(Item item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null)
            {
                itemList[i] = null;
                inventorySlots[i].item = null;
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(Item item)
    {
        bool hasBeenRemoved = Remove(item);

        if (hasBeenRemoved)
        {
            UpdateSlotUI();
        }
    }
    */

}
