using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GymBattleOne : MonoBehaviour
{
    [SerializeField] GameObject combatDialoguePanel;
    [SerializeField] GameObject playerCombatOptions;
    [SerializeField] GameObject fightPanel;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject itemsPanel;
    [SerializeField] GameObject aPBoostSelectionPanel;

    private bool attacking;
    private bool persuading;
    private bool mocking;
    private bool tackleAPIncrease;
    private bool persuadeAPIncrease;
    private bool mockAPIncrease;
    private int inflictedDamageToEnemy;
    private int inflictedDamageToPlayer;

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

    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();



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
        panels.Add("CombatDialogue", combatDialoguePanel);
        panels.Add("PlayerCombatOptions", playerCombatOptions);
        panels.Add("FightPanel", fightPanel);
        panels.Add("confirmPanel", confirmPanel);
        panels.Add("ItemsPanel", itemsPanel);
        panels.Add("APBoosterSelectionPanel", aPBoostSelectionPanel);

        //The initial panel is the player options when the game begins.
        SwitchPanel("PlayerCombatOptions");

    }
    // Update is called once per frame
    void Update()
    {
        UpdateHealthAndNameText();
        UpdateInventory();
        UpdateAP();
    }

    void UpdateHealthAndNameText()
    {
        enemyName.text = "EnemyName: " + enemyCreature.GetEnemyName();
        enemyHealth.text = "HP: " + enemyCreature.GetEnemyHealth() + "/10";
        friendlyName.text = "FriendlyName: " + friendlyCreature.GetFriendlyName();
        friendlyHealth.text = "HP: " + friendlyCreature.GetFriendlyHealth() + "/10";
    }
    void UpdateInventory()
    {
        potionNameText.text = potion.GetItemName();
        potionQuanityText.text = "Quantity: " + potion.GetItemQuantity() + "/5";
        aPBoostNameText.text = aPBoost.GetItemName();
        aPBoostQuantityText.text = "Quantity: " + aPBoost.GetItemQuantity() + "/5";
    }
    void UpdateAP()
    {
        tackleAp.text = "AP: " + friendlyCreature.GetTackleAp() + "/15";
        persuadeAp.text = "AP: " + friendlyCreature.GetPersuadeAp() + "/10";
        mockAp.text = "AP: " + friendlyCreature.GetMockAp() + "/5";
    }

    public void Fight()
    {
        SwitchToFightPanel(); 
    }

    public void Tackle()
    {
        if (friendlyCreature.GetTackleAp() != 0)
        {
            SwitchToConfirmPanel();
            attacking = true;
        }
        else if(friendlyCreature.GetTackleAp() == 0)
        {
            attacking = false;
            StartCoroutine(PlayerRanOutOfAP());
        }
    }

    public void Persuading()
    {
        if (friendlyCreature.GetPersuadeAp() != 0)
        {
            SwitchToConfirmPanel();
             persuading = true;
        }
        else if (friendlyCreature.GetPersuadeAp() == 0)
        {
            persuading = false;
            StartCoroutine(PlayerRanOutOfAP());
        }
    }

    public void Mocking()
    {
        if (friendlyCreature.GetMockAp() != 0)
        {
            SwitchToConfirmPanel();
            mocking = true;
        }
        else if (friendlyCreature.GetMockAp() == 0)
        {
            mocking = false;
            StartCoroutine(PlayerRanOutOfAP());
        }
    }

    /// <summary>
    /// Confirmative Methods
    /// </summary>

    public void ConfirmAction()
    {
        if (attacking)
        {
            if (friendlyCreature.GetTackleAp() <= 15)
            {
                Action("Tackle");
            }
        }
        else if (persuading)
        {
            if (friendlyCreature.GetPersuadeAp() <= 10)
            {
                Action("Persuade");
            }
        }
        if (mocking)
        {
            if (friendlyCreature.GetMockAp() <= 5)
            {
                Action("Mock");
            }
        }
    }

    void Action(string input)
    {
        int accuracy = Random.Range(0, 5);
        
        switch (input)
        {
            case "Tackle":

                if (accuracy >= 2)
                {
                    inflictedDamageToEnemy = friendlyCreature.DoPlayerDamage();
                    enemyCreature.TakeDamage(inflictedDamageToEnemy);
                    UpdateHealthAndNameText();
                    PlayerHitEnemy();
                    friendlyCreature.SpendTackleAP(1);
                }
                else if (accuracy <= 1)
                {
                    PlayerMisses();
                }
                SwitchToCombatDialogue();
                StartCoroutine(EnemyAction());

                break;

            case "Persuade":

                if (accuracy >= 2)
                {
                    SwitchToCombatDialogue();
                    PlayerHitEnemy();
                    UpdateHealthAndNameText();
                    friendlyCreature.SpendPersuadeAP(1);
                    StartCoroutine(EnemyAction());
                }
                else if (accuracy <= 1)
                {
                    SwitchToCombatDialogue();
                    PlayerMisses();
                    persuading = false;
                    StartCoroutine(EnemyAction());
                    
                }
                break;
            
            case "Mock":

                if (accuracy >= 2)
                {
                    inflictedDamageToPlayer = friendlyCreature.DoPlayerDamage();
                    enemyCreature.TakeDamage(inflictedDamageToPlayer);
                    PlayerHitEnemy();
                    UpdateHealthAndNameText();
                    friendlyCreature.SpendMockAP(1);
                }
                else if (accuracy <= 1)
                {
                    PlayerMisses();
                }
                SwitchToCombatDialogue();
                StartCoroutine(EnemyAction());

                break;

        }
    }

    void SelectAPIncrease(string ability)
    {
        switch (ability)
        {
            case "Tackle":

                int increaseTackleAP = aPBoost.GetAPBoost();

                if (friendlyCreature.GetTackleAp() <= 15)
                {
                    friendlyCreature.IncreasePlayerAP(increaseTackleAP);
                    aPBoost.UseItem(1);
                    UpdateAP();
                }
                break;

            case "Persuade":

                int increasePersuadeAP = aPBoost.GetAPBoost();

                if (friendlyCreature.GetPersuadeAp() <= 15)
                {
                    friendlyCreature.IncreasePlayerAP(increasePersuadeAP);
                    aPBoost.UseItem(1);
                    UpdateAP();
                }
                break;

            case "Mock":

                int increaseMockAP = aPBoost.GetAPBoost();

                if (friendlyCreature.GetMockAp() <= 15)
                {
                    friendlyCreature.IncreasePlayerAP(increaseMockAP);
                    aPBoost.UseItem(1);
                    UpdateAP();
                }
                break;

        }
    }
    void EnemyAttacksPlayer()
    {
        int enemyAccuracy = Random.Range(0, 5);

        if (enemyAccuracy >= 2)
        {
            inflictedDamageToPlayer = enemyCreature.DoEnemyDamage();
            friendlyCreature.TakeDamage(inflictedDamageToPlayer);
            UpdateHealthAndNameText();
            EnemyHitPlayer();
        }
        else if (enemyAccuracy <= 1)
        {
            EnemyMisses();
        }
        SwitchToCombatDialogue();
    }



    /// <summary>
    /// Panel Switching Methods
    /// </summary>

    void SwitchPanel(string panelName)
    {
        string currentPanelName;
        foreach (var panel in panels)
        {
            if (panel.Key == panelName)
            {
                panel.Value.SetActive(true);
                currentPanelName = panelName;
            }
            else
            {
                panel.Value.SetActive(false);
            }
        }
    }
    
    void SwitchToFightPanel()
    {
        SwitchPanel("FightPanel");
    }
    void SwitchToConfirmPanel()
    {
        SwitchPanel("confirmPanel");
    }
    void SwitchToCombatDialogue()
    {
        SwitchPanel("CombatDialogue");
    }
    public void SwitchToItemsPanel()
    {
        SwitchPanel("ItemsPanel");
    }
    public void SwitchToAPBoosterSelectionPanel()
    {
        SwitchPanel("APBoosterSelectionPanel");
    }
    public void BackToCombatOptions()
    {
        SwitchPanel("PlayerCombatOptions");
        
        attacking = false;
        persuading = false;
        mocking = false;
        Debug.Log(attacking);
        Debug.Log(persuading);
        Debug.Log(mocking);
        Debug.Log("Fight Cycle Has Ended");
    }

    /// <summary>
    /// Dialogue Changing Methods
    /// </summary>
    void PlayerRanOutOfTackleAP()
    {
        combatText.text = "You cannot use that move, you ran out of AP.";
    }
    void PlayerMisses()
    {
        if(attacking)
        {
            combatText.text = friendlyCreature.GetFriendlyName() + " missed their tackle on " + enemyCreature.GetEnemyName();
        }
        else if(persuading)
        {
            combatText.text = friendlyCreature.GetFriendlyName() + " failed to persuade " + enemyCreature.GetEnemyName();
        }
        if(mocking)
        {
            combatText.text = enemyCreature.GetEnemyName() + " did not care about " + friendlyCreature.GetFriendlyName() + "insults, TRY HARDER!" ;
        }
        
    }
    void PlayerHitEnemy()
    {
        if(attacking)
        {
            combatText.text = friendlyCreature.GetFriendlyName() + " did " + inflictedDamageToEnemy.ToString() + " to " + enemyCreature.GetEnemyName();
        }
        else if(persuading)
        {
            combatText.text = friendlyCreature.GetFriendlyName() + " persuaded " + enemyCreature.GetEnemyName() + " to not attack them"; 
        }
        if(mocking)
        {
            combatText.text = friendlyCreature.GetFriendlyName() + " mocked " + enemyCreature.GetEnemyName() + " into attacking themselves, dealing " + inflictedDamageToPlayer + " points of damage";
        }
        
    }
    void EnemyMisses()
    {
        combatText.text = enemyCreature.GetEnemyName() + " missed an attack on " + friendlyCreature.GetFriendlyName();
    }    

    void EnemyHitPlayer()
    {
        combatText.text = enemyCreature.GetEnemyName() + " did " + inflictedDamageToPlayer.ToString() + " to " + friendlyCreature.GetFriendlyName();
    }

 /// <summary>
 /// Item Usage
 /// </summary>
    public void UsingPotion()
    {
        int healingAmount = potion.GetHealing();

        if (friendlyCreature.GetFriendlyHealth() <= 9)
        {
            friendlyCreature.Heal(healingAmount);
            Debug.Log(friendlyCreature.GetFriendlyHealth());
            potion.UseItem(1);
            UpdateInventory();
        } 
    }
    public void UseAPBooster()
    {
        SwitchToAPBoosterSelectionPanel();
    }
    public void IncreaseTackleAP()
    {
        SelectAPIncrease("Tackle");
    }
    public void IncreasePersuadeAP()
    {
        SelectAPIncrease("Persuade");
    }
    public void IncreaseMockAP()
    {
        SelectAPIncrease("Mock");
    }

    /// <summary>
    /// Combat Cycle Enumerators
    /// </summary>
    IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(2);
        
        if(!persuading)
        {
            EnemyAttacksPlayer();
            yield return new WaitForSeconds(2);
            BackToCombatOptions();
        }
        else
        {
            yield return new WaitForSeconds(2);
            BackToCombatOptions();
        }
    }
    IEnumerator PlayerRanOutOfAP()
    {
        SwitchToCombatDialogue();
        PlayerRanOutOfTackleAP();
        yield return new WaitForSeconds(2);
        SwitchToFightPanel();
    }
}


