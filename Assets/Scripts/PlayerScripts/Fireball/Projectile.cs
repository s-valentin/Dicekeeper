using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float projectileVelocity;
    [HideInInspector] public float projectileDamage;
    [SerializeField] Rigidbody2D rb;

    public float explosionAngle;

    public GameObject fireExplosion;

    private void Start()
    {
        Destroy(gameObject, 3f);    
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * projectileVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.takeDamage(projectileDamage);

            Quaternion explosionRotation = Quaternion.Euler(new Vector3(0, 0, explosionAngle));

            var fireExplosionGFX = Instantiate(fireExplosion, transform.position, transform.rotation); 
            Destroy(fireExplosionGFX, 0.533f);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
    }

}
