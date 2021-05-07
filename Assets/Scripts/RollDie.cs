using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDie : MonoBehaviour
{

    private Sprite[] dieSides;

    [SerializeField] private Image die;

    private bool isNecessary = false;

    private int dieResult = 0;
   
    private void Start()
    {
        dieSides = Resources.LoadAll<Sprite>("DieSides/");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isNecessary)
        {
            StartCoroutine(rollDie());
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

        dieResult = randomDieSide + 1;
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
}
