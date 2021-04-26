using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float projectileVelocity;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        Destroy(gameObject, 4f);        
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * projectileVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
