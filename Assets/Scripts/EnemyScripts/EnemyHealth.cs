using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider slider;


    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;

        
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        slider.value = health;
    }

}
