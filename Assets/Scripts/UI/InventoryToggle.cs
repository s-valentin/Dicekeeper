using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    
    public Canvas canvas;
    public Animator animator;

    private void Start()
    {
        //animator = canvas.GetComponent<Animator>();
    }
    public void OpenInventory()
    {
        
        if(canvas != null)
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
