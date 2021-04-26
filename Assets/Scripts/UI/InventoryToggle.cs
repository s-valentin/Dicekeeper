using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventory;
    private bool isShowing;

    void Update()
    {
        if(Input.GetKeyDown("i") && isShowing == true)
        {
            inventory.SetActive(false);
            isShowing = false;
        }else
        if (Input.GetKeyDown("i") && isShowing == false)
        {
            inventory.SetActive(true);
            isShowing = true;
        }
    }
}
