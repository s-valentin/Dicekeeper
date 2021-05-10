using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireball : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform book;
    [SerializeField] Image fireballImage;

    [SerializeField] float spellPower = 25f;
    [SerializeField] float spellSpeed = 6f;

    [SerializeField] float fireCooldown = 2f;
    bool isCooldown = false;

    private void Awake()
    {
        fireballImage.fillAmount = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isCooldown)
        {
            FireSpell();
            isCooldown = true;
            fireballImage.fillAmount = 1f;
        }       

        if(isCooldown)
        {
            fireballImage.fillAmount -= 1 / fireCooldown * Time.deltaTime;
            if(fireballImage.fillAmount <= 0)
            {
                fireballImage.fillAmount = 0f;
                isCooldown = false;
            }
        }
    }

    private void FireSpell()
    {

        float projectileSpeed = spellSpeed;
        float projectileDamage = spellPower;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Projectile projectile = Instantiate(projectilePrefab, book.position, rot).GetComponent<Projectile>();
        CameraShake.instance.ShakeCamera(1f, .2f);
        projectile.projectileVelocity = projectileSpeed;
        projectile.projectileDamage = projectileDamage;

    }

}
