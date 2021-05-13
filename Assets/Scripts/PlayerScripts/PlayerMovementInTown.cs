using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInTown : MonoBehaviour
{
    [Header("Animation variables")]
    public Animator animator;

    [Header("Movement variables")]
    private Rigidbody2D rb;

    private Vector3 moveDirection;

    [SerializeField] private float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movementX, movementY).normalized;

        animator.SetFloat("Horizontal", movementX);
        animator.SetFloat("Vertical", movementY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }
}
