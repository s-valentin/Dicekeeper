using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{

    public Item[] itemList = new Item[8];
    public List<ShopInventorySlots> shopInventorySlots = new List<ShopInventorySlots>();
    public CurrencyManager ck;

    private void Start()
    {
        //ck = GetComponent<CurrencyManager>();
    }

    private bool Add(Item item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = item;
                shopInventorySlots[i].item = item;
                return true;
            }
        }
        return false;
    }

    public void UpdateSlotUI()
    {
        for (int i = 0; i < shopInventorySlots.Count; i++)
        {
            shopInventorySlots[i].UpdateSlot();
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
        for (int i = itemList.Length - 1; i >= 0; i--)
        {
            if (itemList[i] != null)
            {
                ck.AddCoin(itemList[i].price);
                itemList[i] = null;
                shopInventorySlots[i].item = null;
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
}
