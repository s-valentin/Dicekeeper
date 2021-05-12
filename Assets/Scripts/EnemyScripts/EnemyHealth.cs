using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider slider;

    public GameObject deathEffect;


    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (isDead())
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public bool isDead()
    {
        if (health <= 0)
            return true;
        return false;
    }

    private void OnGUI()
    {
        slider.value = health;
    }

}
