using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [HideInInspector] public float flameWallDamage;

    [SerializeField] float damageFrequency = 0.3f;
    float nextDamage = 0f;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
    }
}
