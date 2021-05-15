using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationManager : MonoBehaviour
{

    [SerializeField] private int reputation = 0;

    [SerializeField] private int minReputation = -100;
    [SerializeField] private int maxReputation = 100;

    public Item.Type type = Item.Type.Default;

    [SerializeField] private int gainedReputation;

    private RollDie rollDie;

    private bool rolledDie = false;

    public Inventory inventory;

    public GameObject legendaryItem;
    private bool hasGivenItem = false;

    public GameObject tradeButtons;

    private CurrencyManager currencyManager;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        rollDie = player.GetComponent<RollDie>();
        inventory = player.GetComponent<Inventory>();
        currencyManager = player.GetComponent<CurrencyManager>();
    }

    public bool checkItemProperty(int index)
    {

        for (int i = 0; i < inventory.itemList.Length; i++)
        {
            if (inventory.itemList[i] != null && i == index)
            {
                if (inventory.itemList[i].type == type)
                {
                    IncreaseReputation();
                    currencyManager.AddCoin(inventory.itemList[i].price - 50);
                }
                else
                {
                    DecreaseReputation();
                    currencyManager.AddCoin(inventory.itemList[i].price + 50);
                }
                
                inventory.itemList[i] = null;
                inventory.inventorySlots[i].item = null;
                return true;
            }
        }
        return false;
    }

    public void acceptItem(int index)
    { 
        bool hasBeenTraded = checkItemProperty(index);

       if (hasBeenTraded)
       {
            inventory.UpdateSlotUI();
       }
       else
       {
           Debug.Log("Pleaca de aici golane");
       }
    }

    private void IncreaseReputation()
    {
        gainedReputation += 5;
    }
    private void DecreaseReputation()
    {
        gainedReputation -= 10;
    }

    private void ModifyReputation()
    {
        reputation += gainedReputation;

        if (reputation < minReputation)
            reputation = minReputation;

        if (reputation > maxReputation)
        {
            reputation = maxReputation;
            SpawnLegendaryItem();
        }
    }

    private void SpawnLegendaryItem()
    {
        if (!hasGivenItem)
        {
            Vector3 position = new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z);
            Instantiate(legendaryItem, position, Quaternion.identity);
            hasGivenItem = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (rollDie.getCooldown())
        {
            rolledDie = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tradeButtons.SetActive(false);
        if (collision.CompareTag("Player"))
        {
            if (rolledDie && rollDie.getCooldown())
            {
                // 4 iteme bune = 20 rep. dai 6 => 20 + 20*6/10 = 32 reputatie
                // 2 iteme bune, 2 rele = -10 rep. dai 6 => -10 + (-10) * 6/10 = -16 reputatie; 
                 
                gainedReputation += (gainedReputation * rollDie.getDieResult()) / 10;
                rolledDie = false;
            }
            ModifyReputation();
            gainedReputation = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tradeButtons.SetActive(true);
    }
}
