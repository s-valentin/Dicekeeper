using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float dashSpeed;

    [SerializeField] private float dashTime; // din asta se scade pana ajunge la 0
    [SerializeField] private float startDashTime; // initial dashTime value

    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        
        if(direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = 1;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                Debug.Log(direction);
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    Debug.Log(rb.velocity);
                }
            }
        }

    }
}
