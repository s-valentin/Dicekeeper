using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackUp : MonoBehaviour
{
    public float attackDamage = 15f;

    public PolygonCollider2D hitCollider;

    public void startAttack()
    {
        hitCollider.gameObject.SetActive(true);
        StartCoroutine(disableCollider());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
        }
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(0.1f);
        hitCollider.gameObject.SetActive(false);
    }


    public void updateDamage(float damage)
    {
        attackDamage += damage;
    }
}
