using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float projectileVelocity;
    [HideInInspector] public float projectileDamage;
    [SerializeField] Rigidbody2D rb;

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
        // enemy collision
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.takeDamage(projectileDamage);

            var fireExplosionGFX = Instantiate(fireExplosion, transform.position, transform.rotation); 
            Destroy(fireExplosionGFX, 0.533f);
        }
        // boss/miniboss collision
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
            BossHealth boss = collision.gameObject.GetComponent<BossHealth>();
            boss.takeDamage(projectileDamage);

            var fireExplosionGFX = Instantiate(fireExplosion, transform.position, transform.rotation);
            Destroy(fireExplosionGFX, 0.533f);
        }
        if (collision.gameObject.CompareTag("MiniBoss"))
        {
            Destroy(gameObject);
            MiniBossHealth miniBoss = collision.gameObject.GetComponent<MiniBossHealth>();
            miniBoss.takeDamage(projectileDamage);

            var fireExplosionGFX = Instantiate(fireExplosion, transform.position, transform.rotation);
            Destroy(fireExplosionGFX, 0.533f);
        }
        // wall collision
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        // unnecessary, just in case player collision
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
