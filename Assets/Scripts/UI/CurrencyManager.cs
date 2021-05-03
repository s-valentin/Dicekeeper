using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{

    #region Singleton

    public static CurrencyManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of CurrencyManager found!");
            return;
        }
        instance = this;
    }

    #endregion

    public float coinAmount;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = coinAmount.ToString();
    }

    public void AddCoin(float value)
    {
        coinAmount += Convert.ToInt32(value);
        UpdateUI();
        Debug.Log("Total Coins: " + coinAmount);
    }

    public void RemoveCoin(float value)
    {
        coinAmount -= Convert.ToInt32(value);
        UpdateUI();
        Debug.Log("Total Coins: " + coinAmount);
    }

    public void UpdateUI()
    {
        coinText.text = coinAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
