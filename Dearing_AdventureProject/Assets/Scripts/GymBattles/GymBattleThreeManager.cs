using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the UI data initialization for GymBattleThree
/// </summary>
public class GymBattleThreeManager : MonoBehaviour
{
    public static GymBattleThreeManager Instance;

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
    [SerializeField] TMP_Text tackleAPSetOne;
    [SerializeField] TMP_Text persuadeAPSetOne;
    [SerializeField] TMP_Text mockAPSetOne;
    [SerializeField] TMP_Text tackleAPSetTwo;
    [SerializeField] TMP_Text persuadeAPSetTwo;
    [SerializeField] TMP_Text mockAPSetTwo;



    private EnemyCreature enemyCreature;
    private FriendlyCreature friendlyCreature;


    private PlayerItems potion;
    private PlayerItems aPBoost;

    private bool activeGymBattle;


    private void Awake()
    {

        enemyCreature = EnemyCreature.Create("Sratha", 40, 20, false);
        friendlyCreature = FriendlyCreature.Create("Rexasourus", 40, 20, 25, 20, 15, false);

        //Creation of Enemy, and Friendly Items
        potion = PlayerItems.Create("Potion", 15, 0, 5);
        aPBoost = PlayerItems.Create("APBoost", 0, 8, 5);
    }


    // Start is called before the first frame update
    void Start()
    {
        activeGymBattle = true;
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
        PlayerDied();
        PlayerWonTheBattle();
    }

    public GymBattleThreeManager()
    {
        Instance = this;
    }

    public void UpdateHealthAndNameText()
    {
        enemyName.text = enemyCreature.GetEnemyName();
        enemyHealth.text = "HP: " + enemyCreature.GetEnemyHealth() + "/40";
        friendlyName.text = friendlyCreature.GetFriendlyName();
        friendlyHealth.text = "HP: " + friendlyCreature.GetFriendlyHealth() + "/40";
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
        tackleAPSetOne.text = "AP: " + friendlyCreature.GetTackleAP() + "/25";
        persuadeAPSetOne.text = "AP: " + friendlyCreature.GetPersuadeAP() + "/20";
        mockAPSetOne.text = "AP: " + friendlyCreature.GetMockAP() + "/15";
        tackleAPSetTwo.text = "AP: " + friendlyCreature.GetTackleAP() + "/25";
        persuadeAPSetTwo.text = "AP: " + friendlyCreature.GetPersuadeAP() + "/20";
        mockAPSetTwo.text = "AP: " + friendlyCreature.GetMockAP() + "/15";
    }

    void PlayerDied()
    {
        if (friendlyCreature.GetFriendlyHealth() <= 0)
        {
            PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerDiedDialogue());
        }
    }

    public void PlayerWonTheBattle()
    {
        if (friendlyCreature.GetFriendlyHealth() > 0 && enemyCreature.GetEnemyHealth() <= 0)
        {
            
            PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerWonTheBattleDialogue());

        }
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
    public bool ReturnBattleStatus()
    {
        return this.activeGymBattle;
    }
    public void SetBattleStatus(bool value)
    {
        activeGymBattle = value;
    }
}


