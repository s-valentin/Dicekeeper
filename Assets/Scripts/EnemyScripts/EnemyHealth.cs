using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected Slider slider;

    public GameObject deathEffect;

    public GameObject[] items;


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
            dropItem();
        }
    }

    private void dropItem()
    {
        int number = Random.Range(0, 7);
        Instantiate(items[number], transform.position, Quaternion.identity);
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
