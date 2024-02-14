using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GymBattleOneManager : MonoBehaviour
{
    public static GymBattleOneManager Instance;

    /// <summary>
    /// These are text spaces that are used during the battle
    /// </summary>
    private TMP_Text enemyName;
    private TMP_Text friendlyName;
    private TMP_Text enemyHealth;
    private TMP_Text friendlyHealth;
    private TMP_Text combatText;
    private TMP_Text potionQuanityText;
    private TMP_Text potionNameText;
    private TMP_Text aPBoostNameText;
    private TMP_Text aPBoostQuantityText;
    private TMP_Text tackleAp;
    private TMP_Text persuadeAp;
    private TMP_Text mockAp;



    private EnemyCreature enemyCreature;
    private FriendlyCreature friendlyCreature;

    private PlayerItems potion;
    private PlayerItems aPBoost;
    private PlayerItems enemyPotion;

    



    // Start is called before the first frame update
    void Start()
    {
        //Creation of Enemy, and Friendly Creature
        enemyCreature = EnemyCreature.Create("Barnabus", 10);
        friendlyCreature = FriendlyCreature.Create("Rexasourus", 10, 15, 10, 5);

        //Creation of Enemy, and Friendly Items
        potion = PlayerItems.Create("Potion", 5, 0, 5);
        aPBoost = PlayerItems.Create("APBoost", 0, 3, 5);

        //This is where the text is aquired through the code
        enemyName = GameObject.Find("EnemyName").GetComponent<TMP_Text>();
        friendlyName = GameObject.Find("PlayerName").GetComponent<TMP_Text>();
        enemyHealth = GameObject.Find("EnemyHealth").GetComponent<TMP_Text>();
        friendlyHealth = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
        combatText = GameObject.Find("CombatText").GetComponent<TMP_Text>();
        potionNameText = GameObject.Find("PotionText").GetComponent<TMP_Text>();
        potionQuanityText = GameObject.Find("PotionQuantityText").GetComponent<TMP_Text>();
        aPBoostNameText = GameObject.Find("APBoostText").GetComponent<TMP_Text>();
        aPBoostQuantityText = GameObject.Find("APBoostQuantityText").GetComponent<TMP_Text>();
        tackleAp = GameObject.Find("TackleAP").GetComponent<TMP_Text>();
        persuadeAp = GameObject.Find("PersuadeAP").GetComponent<TMP_Text>();
        mockAp = GameObject.Find("MockAP").GetComponent<TMP_Text>();


        //this is where the panels are added to the dictionary
       

    }
    // Update is called once per frame
    void Update()
    {
        UpdateHealthAndNameText();
        UpdateInventory();
        UpdateAP();
    }

    public void UpdateHealthAndNameText()
    {
        enemyName.text = "EnemyName: " + enemyCreature.GetEnemyName();
        enemyHealth.text = "HP: " + enemyCreature.GetEnemyHealth() + "/10";
        friendlyName.text = "FriendlyName: " + friendlyCreature.GetFriendlyName();
        friendlyHealth.text = "HP: " + friendlyCreature.GetFriendlyHealth() + "/10";
    }
    public void UpdateInventory()
    {
        potionNameText.text = potion.GetItemName();
        potionQuanityText.text = "Quantity: " + potion.GetItemQuantity() + "/5";
        aPBoostNameText.text = aPBoost.GetItemName();
        aPBoostQuantityText.text = "Quantity: " + aPBoost.GetItemQuantity() + "/5";
    }
    public void UpdateAP()
    {
        tackleAp.text = "AP: " + friendlyCreature.GetTackleAp() + "/15";
        persuadeAp.text = "AP: " + friendlyCreature.GetPersuadeAp() + "/10";
        mockAp.text = "AP: " + friendlyCreature.GetMockAp() + "/5";
    }
    public TMP_Text ReturnCombatText()
    {
        return this.combatText;
    }
    public FriendlyCreature ReturnFriendlyCreature()
    {
        return this.friendlyCreature;
    }
    public EnemyCreature ReturnEnemyCreature()
    {
        return this.enemyCreature;
    }
    public PlayerItems ReturnPotion()
    {
        return this.potion;
    }
    public PlayerItems ReturnAPBoost()
    {
        return this.aPBoost;
    }
}


