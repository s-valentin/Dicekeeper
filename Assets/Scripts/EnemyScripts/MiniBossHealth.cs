using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBossHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider slider;

    private Animator animator;

    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        animator = GetComponent<Animator>();
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, 2.25f);
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

    public bool isDead()
    {
        if (health <= 0)
            return true;
        return false;
    }
}
