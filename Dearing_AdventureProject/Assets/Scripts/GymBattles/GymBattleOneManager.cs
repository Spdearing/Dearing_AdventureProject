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
    private TMP_Text enemyLevel;
    private TMP_Text friendlyLevel;
    private TMP_Text enemyHealth;
    private TMP_Text friendlyHealth;
    [SerializeField] TMP_Text potionQuanityText;
    [SerializeField] TMP_Text potionNameText;
    [SerializeField] TMP_Text aPBoostNameText;
    [SerializeField] TMP_Text aPBoostQuantityText;
    [SerializeField] TMP_Text tackleAp;
    [SerializeField] TMP_Text persuadeAp;
    [SerializeField] TMP_Text mockAp;



    private EnemyCreature enemyCreature;
    private FriendlyCreature friendlyCreature;

    private PlayerItems potion;
    private PlayerItems aPBoost;


    private void Awake()
    {
        enemyCreature = EnemyCreature.Create("Barnabus", 10, 5);
        friendlyCreature = FriendlyCreature.Create("Rexasourus", 10, 5, 15, 10, 5);

        //Creation of Enemy, and Friendly Items
        potion = PlayerItems.Create("Potion", 5, 0, 5);
        aPBoost = PlayerItems.Create("APBoost", 0, 3, 5);
    }


    // Start is called before the first frame update
    void Start()
    {
        enemyName = GameObject.Find("EnemyName").GetComponent<TMP_Text>();
        friendlyName = GameObject.Find("PlayerName").GetComponent<TMP_Text>();
        enemyLevel = GameObject.Find("EnemyLevelText").GetComponent<TMP_Text>();
        friendlyLevel = GameObject.Find("PlayerLevelText").GetComponent<TMP_Text>();
        enemyHealth = GameObject.Find("EnemyHealth").GetComponent<TMP_Text>();
        friendlyHealth = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateHealthAndNameText();
        UpdateInventory();
        UpdateAP();
        UpdateLevel();
    }

    public GymBattleOneManager()
    {
        Instance = this;
    }

    public void UpdateHealthAndNameText()
    {
        enemyName.text = enemyCreature.GetEnemyName();
        enemyHealth.text = "HP: " + enemyCreature.GetEnemyHealth() + "/10";
        friendlyName.text = friendlyCreature.GetFriendlyName();
        friendlyHealth.text = "HP: " + friendlyCreature.GetFriendlyHealth() + "/10";
    }
    public void UpdateInventory()
    {
        potionNameText.text = potion.GetItemName();
        potionQuanityText.text = "Quantity: " + potion.GetItemQuantity() + "/5";
        aPBoostNameText.text = aPBoost.GetItemName();
        aPBoostQuantityText.text = "Quantity: " + aPBoost.GetItemQuantity() + "/5";
    }
    public void UpdateLevel()
    {
        friendlyLevel.text = "Level: " + friendlyCreature.GetLevel().ToString();
        enemyLevel.text = "Level: " + enemyCreature.GetLevel().ToString();
    }
    public void UpdateAP()
    {
        tackleAp.text = "AP: " + friendlyCreature.GetTackleAp() + "/15";
        persuadeAp.text = "AP: " + friendlyCreature.GetPersuadeAp() + "/10";
        mockAp.text = "AP: " + friendlyCreature.GetMockAp() + "/5";
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


