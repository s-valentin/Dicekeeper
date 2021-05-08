using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventorySlots : MonoBehaviour
{
    public Item item;
    public GameObject itemInGame;


    public void UpdateSlot()
    {
        if (item != null)
        {
            itemInGame.GetComponent<SpriteRenderer>().sprite = item.icon;
            itemInGame.SetActive(true);
        }
        else
        {
            itemInGame.SetActive(false);
        }
    }
}
