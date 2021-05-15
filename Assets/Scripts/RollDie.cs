using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDie : MonoBehaviour
{

    private Sprite[] dieSides;

    [SerializeField] private Image die;

    [SerializeField] private Image dieCooldown;

    private float rollCooldown = 10f;

    private bool isNecessary = false;

    private int dieResult = 0;

    private bool isCooldown = false;
   
    private void Start()
    {
        dieSides = Resources.LoadAll<Sprite>("DieSides/");
        dieCooldown.fillAmount = 0f;
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.R) && isNecessary && !isCooldown)
            {
                isCooldown = true;
                dieCooldown.fillAmount = 1f;
                StartCoroutine(rollDie());
            }
            else if (isCooldown)
            {
                dieCooldown.fillAmount -= 1f / rollCooldown * Time.deltaTime;
                if (dieCooldown.fillAmount == 0f)
                {
                    isCooldown = false;
                }
            }
    }

    IEnumerator rollDie()
    {
        int randomDieSide = 0;

        for(int i = 0; i <= 10; i++)
        {
            randomDieSide = Random.Range(0, 5);
            die.sprite = dieSides[randomDieSide];

            yield return new WaitForSeconds(0.1f);
        }
        dieCooldown.sprite = die.sprite;

        dieResult = randomDieSide + 1;
        Debug.Log(dieResult);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DiceEvent"))
        {
            isNecessary = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DiceEvent"))
            isNecessary = false;
    }

    public int getDieResult()
    {
        return dieResult;
    }

    public bool getCooldown()
    {
        return isCooldown;
    }
}
