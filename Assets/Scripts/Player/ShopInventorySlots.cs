using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventorySlots : MonoBehaviour
{
    public Item item;
    public GameObject icon;


    public void UpdateSlot()
    {
        if (item != null)
        {
            icon.GetComponent<SpriteRenderer>().sprite = item.icon;
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }
}
