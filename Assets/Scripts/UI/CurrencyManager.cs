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
        paymentSlider.maxValue = paymentCooldown;
        paymentSlider.value = 0;
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

    float payment = 50;
    Boolean isPayed = false;
    [SerializeField]float paymentCooldown = 2f;
    float nextPayment = 0f;
    Boolean isPayable = true;
    [SerializeField] Slider paymentSlider;
    Boolean isInRange = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Landlord"))
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Landlord"))
        isInRange = false;
    }
    public void PayLandlord()
    {
        if (isInRange) { 
        if (isPayable)
        {
            if (!isPayed)
            {
                if(coinAmount > payment)
                {
                    coinAmount -= payment;
                    isPayed = true;
                    isPayable = false;
                    payment += 50;
                    nextPayment = Time.time + paymentCooldown;
                    UpdateUI();
                }
                else
                {
                    
                    isPayed = false;
                    Debug.Log("Cannot pay. Not enough mooney");
                }
            }
        }
        }
    }
    public void UpdateUI()
    {
        coinText.text = coinAmount.ToString();
    }

    // Update is called once per frame
    
    void Update()
    {
        paymentSlider.value = nextPayment - Time.time;
        if (Time.time > nextPayment && Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            PayLandlord();
            
        }
        if(paymentSlider.value == 0)
        {
            isPayed = false;
            isPayable = true;
        }
    }
}
