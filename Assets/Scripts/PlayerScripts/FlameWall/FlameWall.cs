using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameWall : MonoBehaviour
{
    [SerializeField] GameObject flameWallPrefab;
    [SerializeField] Transform book;
    [SerializeField] Image flameWallImage;

    [SerializeField] SpriteRenderer rangeIndicator;

    private float spellPower = 20f;

    [SerializeField] float fireCooldown = 2f;
    bool isCooldown = false;

    private void Awake()
    {
        flameWallImage.fillAmount = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && !isCooldown)
        {
            
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 2.0f;
            //Debug.Log(mousePosition.x + " " + mousePosition.y);

            Vector3 objectPosition;
            objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (Vector3.Distance(objectPosition, transform.position) < 13.5)
            {
                FireSpell(objectPosition);
                isCooldown = true; 
                flameWallImage.fillAmount = 1f;
            }
            else
            {
                StartCoroutine(showRange());
            }
        }

        if (isCooldown)
        {
            flameWallImage.fillAmount -= 1 / fireCooldown * Time.deltaTime;
            if(flameWallImage.fillAmount <= 0f)
            {
                flameWallImage.fillAmount = 0f;
                isCooldown = false;
            }
        }
    }


    private void FireSpell(Vector3 objectPosition)
    {
        Debug.Log(objectPosition);
        //flameWallGFX.enabled = true;

        float angle = Utility.AngleTowardsMouse(book.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Wall flameWall = Instantiate(flameWallPrefab, objectPosition, rot).GetComponent<Wall>();
        CameraShake.instance.ShakeCamera(.7f, .35f);
        flameWall.flameWallDamage = spellPower;
    }

    IEnumerator showRange()
    {
        rangeIndicator.enabled = true;
        yield return new WaitForSeconds(0.75f);
        rangeIndicator.enabled = false;
    }
}
