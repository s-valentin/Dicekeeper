using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    // SerializeField allows the variable to be edited inside the Unity editor

    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    // This function modifies the health of the player
    public void UpdateHealth(float modification)
    {
        health += modification;

        if (health > maxHealth)
            health = maxHealth;
        else if (health <= 0)
        {
            health = 0f;
            healthSlider.value = 0f;
            Destroy(gameObject);
        }
        
    }

    private void OnGUI()
    {
        // This makes it so that your health slides instead of being chunked out.
        float time = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, time);      
    }

}
