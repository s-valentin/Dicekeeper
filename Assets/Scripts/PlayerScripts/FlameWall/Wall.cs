using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [HideInInspector] public float flameWallDamage;
    private CircleCollider2D circleCollider2D;
    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        Destroy(gameObject, 0.733f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(disableCollider());
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.takeDamage(flameWallDamage);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(0.2f);
        circleCollider2D.enabled = false;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collision.isTrigger)
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.takeDamage(flameWallDamage);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collision.isTrigger)
        {
            if (Time.time > nextDamage)
            {
                EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
                enemy.takeDamage(flameWallDamage);
                nextDamage = Time.time + damageFrequency;
            }
        }
    }*/
}
