using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAttack : MonoBehaviour
{
    public float attackDamage = 10f;

    public PolygonCollider2D leftCollider;
    public PolygonCollider2D rightCollider;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void startAttack()
    {
        if(animator.GetBool("isFlipped") == false)
            rightCollider.gameObject.SetActive(true);
        else
            leftCollider.gameObject.SetActive(true);

        StartCoroutine(disableCollider());
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(0.1f);
        rightCollider.gameObject.SetActive(false);
        leftCollider.gameObject.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.leftCollider.isActiveAndEnabled || this.rightCollider.isActiveAndEnabled)
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
        }
    }*/
}
