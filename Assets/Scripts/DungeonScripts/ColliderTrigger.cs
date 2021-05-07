using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player entered area");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }
}
