using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackUp : MonoBehaviour
{
    [SerializeField] private float attackDamage = 5f;

    public PolygonCollider2D hitCollider;

    public void startAttack()
    {
        hitCollider.gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            //hitCollider.gameObject.SetActive(false);
            //TODO REPARA SI FA-L DRACULUI SA NU ITI DEA ONE SHOT
        }
    }


}
