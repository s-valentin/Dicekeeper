using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Item[] itemList = new Item[9];
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public ShopInventory si;

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


    private bool Remove()
    {
        for (int i = itemList.Length-1; i >= 0; i--)
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

    public void RemoveItem()
    {
        
        bool hasBeenRemoved = Remove();

        if (hasBeenRemoved)
        {
            UpdateSlotUI();
        }
    }

    public bool Sell(int index)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null && i == index)
            {
                si.AddItem(itemList[i]);
                itemList[i] = null;
                inventorySlots[i].item = null;
                return true;
            }
        }
        return false;
    }

    public void SellItem(int index)
    {
        bool hasBeenSold = Sell(index);

        if (hasBeenSold)
        {
            UpdateSlotUI();
        }
    }
    

}
