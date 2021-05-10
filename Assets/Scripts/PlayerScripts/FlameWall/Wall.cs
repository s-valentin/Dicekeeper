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
        // disable the collider created for a small push effect
        StartCoroutine(disableCollider());

        // enemy collision
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.takeDamage(flameWallDamage);
        }

        // boss/miniboss collision
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth boss = collision.gameObject.GetComponent<BossHealth>();
            boss.takeDamage(flameWallDamage);
            Debug.Log("aa");
        }
        if (collision.gameObject.CompareTag("MiniBoss"))
        {
            Destroy(gameObject);
            MiniBossHealth miniBoss = collision.gameObject.GetComponent<MiniBossHealth>();
            miniBoss.takeDamage(flameWallDamage);
        }
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(0.2f);
        circleCollider2D.enabled = false;
    }

}
