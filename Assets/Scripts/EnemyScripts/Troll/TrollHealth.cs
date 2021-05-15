using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollHealth : EnemyHealth
{

    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    private void OnGUI()
    {
        slider.value = health;
    }

}
