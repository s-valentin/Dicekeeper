using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject inventoryPanel;
    public GameObject sellButtons;
    public InventoryToggle itAnim;
    bool isInRange;

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
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
        if (Input.GetKeyDown(KeyCode.E)) {
        shopPanel.SetActive(true);
        sellButtons.SetActive(true);
        itAnim.animator.SetBool("open", true);
        }
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        sellButtons.SetActive(false);
        itAnim.animator.SetBool("open", false);
    }


}
