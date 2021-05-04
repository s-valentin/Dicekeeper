using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireball : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] SpriteRenderer projectileGFX;
    [SerializeField] Transform book;
    [SerializeField] Slider spellSlider; 


    [SerializeField] float spellPower = 25f;
    [SerializeField] float spellSpeed = 6f;

    [SerializeField] float fireCooldown = 2f;
    float nextFireTime = 0f;

    private void Awake()
    {
        spellSlider.maxValue = fireCooldown;
    }

    private void Update()
    {
        spellSlider.value = nextFireTime - Time.time;
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            FireSpell();
            nextFireTime = Time.time + fireCooldown;
        }       
    }

    private void FireSpell()
    {
        projectileGFX.enabled = true;

        float projectileSpeed = spellSpeed;
        float projectileDamage = spellPower;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f)); // rotates the projectile to the right

        Projectile projectile = Instantiate(projectilePrefab, book.position, rot).GetComponent<Projectile>();
        projectile.projectileVelocity = projectileSpeed;
        projectile.projectileDamage = projectileDamage;

        projectileGFX.enabled = false;
    }

}
