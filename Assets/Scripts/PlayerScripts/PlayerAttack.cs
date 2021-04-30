using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] SpriteRenderer projectileGFX;
    [SerializeField] Slider spellChargeSlider;
    [SerializeField] Transform book;

    [SerializeField] float spellPower;

    [Range(0, 2)]
    [SerializeField] float maxSpellCharge;

    float spellCharge;

    bool canFire = true;

    private float fireCooldown = 3f;
    private float nextFire = 0f;

    private void Start()
    {
        spellChargeSlider.value = 0f;
        spellChargeSlider.maxValue = maxSpellCharge;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            ChargeSpell();
        }
        else if (Input.GetMouseButtonUp(0) && canFire)
        {
            FireSpell();
        }
        else
        {
            if (spellCharge > 0f)
            {
                spellCharge -= 1f * Time.deltaTime;
            }
            else
            {
                spellCharge = 0;
                canFire = true;
            }

            spellChargeSlider.value = spellCharge;

        }
    }

    private void ChargeSpell()
    {
        projectileGFX.enabled = true;
        spellCharge += Time.deltaTime;

        spellChargeSlider.value = spellCharge;

        if (spellCharge > maxSpellCharge)
        {
            spellChargeSlider.value = maxSpellCharge;
        }
    }


    private void FireSpell()
    {
        if (spellCharge > maxSpellCharge)
            spellCharge = maxSpellCharge;

        float projectileSpeed = spellCharge + spellPower;
        float projectileDamage = spellCharge * spellPower;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f)); // rotates the projectile to the right

        Projectile projectile = Instantiate(projectilePrefab, book.position, rot).GetComponent<Projectile>();
        projectile.projectileVelocity = projectileSpeed;
        projectile.projectileDamage = projectileDamage;

        canFire = false;
        projectileGFX.enabled = false;
    }
}


/*
 *  private void Update()
    {
        if(Input.GetMouseButton(0) && canFire)
        {
            ChargeSpell();
        } 
        else if(Input.GetMouseButtonUp(0) && canFire)
        {
            FireSpell();
        }
        else
        {
            if(spellCharge > 0f)
            {
                spellCharge -= 1f * Time.deltaTime;
            }
            else
            {
                spellCharge = 0;
                canFire = true;
            }

            spellChargeSlider.value = spellCharge;
            
        }
    }

    private void ChargeSpell()
    {
        projectileGFX.enabled = true;
        spellCharge += Time.deltaTime;

        spellChargeSlider.value = spellCharge;

        if(spellCharge > maxSpellCharge)
        {
            spellChargeSlider.value = maxSpellCharge;
        }
    }


    private void FireSpell()
    {
        if (spellCharge > maxSpellCharge)
            spellCharge = maxSpellCharge;

        float projectileSpeed = spellCharge + spellPower;
        float projectileDamage = spellCharge * spellPower;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f)); // rotates the projectile to the right

        Projectile projectile = Instantiate(projectilePrefab, book.position, rot).GetComponent<Projectile>();
        projectile.projectileVelocity = projectileSpeed;
        projectile.projectileDamage = projectileDamage;

        canFire = false;
        projectileGFX.enabled = false;
    }
*/