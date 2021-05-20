using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : EnemyHealth
{
    //[SerializeField] private float health;
    //[SerializeField] private float maxHealth;
    //[SerializeField] private Slider slider;
    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public new void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            animator.SetTrigger("Death");
            Destroy(gameObject, 2.25f);
        }

        if(health <= maxHealth / 2)
        {
            GetComponent<BossAttackUp>().updateDamage(2f);
            animator.SetBool("IsStageTwo", true);
            spriteRenderer.color = Color.red;
        }
    }

    private void OnGUI()
    {
        slider.value = health;
    }
    public float getCurrentHealth()
    {
        return health;
    }
}
