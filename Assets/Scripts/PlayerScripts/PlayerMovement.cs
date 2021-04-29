using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private Vector3 moveDirection;

    [SerializeField] private float moveSpeed;

    public bool isDashButtonDown;
    private float dashSpeed = 2f;

    [SerializeField] private LayerMask dashLayerMask;

    public GameObject dashEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
       
        moveDirection = new Vector2(movementX, movementY).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }
    
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;

        if (isDashButtonDown)
        {
            CameraShake.instance.ShakeCamera(1f, .1f);
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            rb.MovePosition(transform.position + moveDirection * dashSpeed);

            // Verific daca ma lovesc de pereti
            Vector3 dashPosition = transform.position + moveDirection * dashSpeed;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDirection, dashSpeed, dashLayerMask);

            if (raycastHit2d.collider != null)
                dashPosition = raycastHit2d.point;
            

            rb.MovePosition(dashPosition);

            isDashButtonDown = false;
        }

        
    }

}
