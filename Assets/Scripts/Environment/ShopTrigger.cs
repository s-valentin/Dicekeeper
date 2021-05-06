using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject inventoryPanel;
    bool isInRange;

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.L))
        {
            OpenShop();
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("In Range for Shop");
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            CloseShop();
            Debug.Log("Not In Range for Shop");
        }
    }


    void OpenShop()
    {
        if (Input.GetKeyDown(KeyCode.L)) { 
        shopPanel.SetActive(true);
        inventoryPanel.SetActive(true);
        }
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }


}
