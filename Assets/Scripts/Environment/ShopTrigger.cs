using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject inventoryPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OpenShop();
        Debug.Log("EnteringShop");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            CloseShop();
        Debug.Log("Exiting shop");
    }

    void OpenShop()
    {
        shopPanel.SetActive(true);
        inventoryPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }


}
