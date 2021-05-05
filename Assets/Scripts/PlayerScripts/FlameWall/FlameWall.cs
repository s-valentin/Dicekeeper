using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameWall : MonoBehaviour
{
    [SerializeField] GameObject flameWallPrefab;
    [SerializeField] Transform book;

    [SerializeField] SpriteRenderer rangeIndicator;

    private float spellPower = 3f;

    [SerializeField] float fireCooldown = 2f;
    float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(1) && Time.time > nextFireTime)
        {

            nextFireTime = Time.time + fireCooldown;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 2.0f;
            //Debug.Log(mousePosition.x + " " + mousePosition.y);

            

            Vector3 objectPosition;
            objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if(Vector3.Distance(objectPosition, transform.position) < 13.5)
                FireSpell(objectPosition);
            else
            {
                StartCoroutine(showRange());
            }
        }
    }


    private void FireSpell(Vector3 objectPosition)
    {
        Debug.Log(objectPosition);
        //flameWallGFX.enabled = true;

        float damage = spellPower;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Wall flameWall = Instantiate(flameWallPrefab, objectPosition, rot).GetComponent<Wall>();
        flameWall.flameWallDamage = damage;
    }

    IEnumerator showRange()
    {
        rangeIndicator.enabled = true;
        yield return new WaitForSeconds(0.75f);
        rangeIndicator.enabled = false;
    }
}
