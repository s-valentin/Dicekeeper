using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{

    //Still working on this.
    
    public GameObject inventory;
    public GameObject Panel;
    Animator animator;
    bool isOpen;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void OpenInventory()
    {
        isOpen = animator.GetBool("open");
        animator.SetBool("open", !isOpen);
        animator.Play("open");
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
            inventory.SetActive(!isOpen);
        }
    }
}
