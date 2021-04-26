using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] SpriteRenderer projectileGFX;
    [SerializeField] Slider spellPowerSlider;
    [SerializeField] Transform book;

    [Range(0, 10)]
    [SerializeField] float spellPower;

    [Range(0, 3)]
    [SerializeField] float maxSpellCharge;

    float spellCharge;

    bool canFire = true;

    private void Start()
    {
        spellPowerSlider.value = 0f;
        spellPowerSlider.maxValue = maxSpellCharge;
    }

    private void Update()
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

            spellPowerSlider.value = spellCharge;
            
        }
    }

    private void ChargeSpell()
    {
        projectileGFX.enabled = true;
        spellCharge += Time.deltaTime;

        spellPowerSlider.value = spellCharge;

        if(spellCharge > maxSpellCharge)
        {
            spellPowerSlider.value = maxSpellCharge;
        }
    }


    private void FireSpell()
    {
        if (spellCharge > maxSpellCharge)
            spellCharge = maxSpellCharge;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f)); // rotates the projectile to the right

        Projectile projectile = Instantiate(projectilePrefab, book.position, rot).GetComponent<Projectile>();
        projectile.projectileVelocity = 5f;

        canFire = false;
        projectileGFX.enabled = false;
    }
}
