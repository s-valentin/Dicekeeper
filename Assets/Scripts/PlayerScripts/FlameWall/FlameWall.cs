using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWall : MonoBehaviour
{
    [SerializeField] GameObject flameWallPrefab;
    //[SerializeField] SpriteRenderer flameWallGFX;
    [SerializeField] Transform book;

    private float spellPower = 3f;

    [SerializeField] float fireCooldown = 2f;
    float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(1) && Time.time > nextFireTime)
        {
            FireSpell();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    private void FireSpell()
    {
        //flameWallGFX.enabled = true;

        float damage = spellPower;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Wall flameWall = Instantiate(flameWallPrefab, book.position, rot).GetComponent<Wall>();
        flameWall.flameWallDamage = damage;
    }
}
