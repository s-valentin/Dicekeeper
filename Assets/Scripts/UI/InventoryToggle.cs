using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    
    public GameObject Panel;
    public Animator animator;

    private void Start()
    {
        animator = Panel.GetComponent<Animator>();
    }
    public void OpenInventory()
    {
        
        if(Panel != null)
        {
            
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }
}
