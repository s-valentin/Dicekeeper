using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3f;

    private Transform target;
        
    private Rigidbody2D rb;
    
    [SerializeField] BoxCollider2D playerCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            Debug.Log(distance);
            if (distance > 0.84)
            {
                rb.isKinematic = false;
                float step = movementSpeed * Time.deltaTime;
                rb.position = Vector3.MoveTowards(rb.position, target.position, step);
            }
            else
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
                return;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            target = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            target = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
            target = collision.transform;
    }

}
