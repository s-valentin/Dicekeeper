using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollMovement : MonoBehaviour
{
    public float movementSpeed = 2.5f;

    private Transform target;

    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                spriteRenderer.flipX = true;
                animator.SetBool("isFlipped", true);
            }
            else
            {
                spriteRenderer.flipX = false;
                animator.SetBool("isFlipped", false);
            }
            
            float step = movementSpeed * Time.deltaTime;
            rb.position = Vector3.MoveTowards(rb.position, target.position, step);
            animator.SetBool("isWalking", true);

            Debug.Log(Vector3.Distance(rb.position, target.position));

            if (Vector3.Distance(rb.position, target.position) < 1.3)
            {
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
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