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
    [SerializeField] GameObject ItemsPanel;

    private bool attacking;
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
        panels.Add("CombatDialogue", combatDialoguePanel);//panels(0)
        panels.Add("PlayerCombatOptions", playerCombatOptions);//panels(1)
        panels.Add("FightPanel", fightPanel);//panels(2)
        panels.Add("confirmPanel", confirmPanel);//panels(3)
        panels.Add("ItemsPanel", ItemsPanel);//panels(4)

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

    void Action(string input)
    {
        switch (input)
        {
            case "Tackle":

                int accuracy = Random.Range(0, 5);

                if (accuracy >= 2)
                {
                    inflictedDamageToEnemy = friendlyCreature.DoPlayerDamage();
                    enemyCreature.TakeDamage(inflictedDamageToEnemy);
                    UpdateHealthAndNameText();
                    PlayerHitEnemy();
                    friendlyCreature.SpendTackleAp(1);
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
    public void BackToCombatOptions()
    {
        SwitchPanel("PlayerCombatOptions");
        attacking = !attacking;
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
        combatText.text = friendlyCreature.GetFriendlyName() + " missed an attack on " + enemyCreature.GetEnemyName();
    }
    void PlayerHitEnemy()
    {
        combatText.text = friendlyCreature.GetFriendlyName() + " did " + inflictedDamageToEnemy.ToString() + " to " + enemyCreature.GetEnemyName();
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
    /// Confirmative Methods
    /// </summary>

    public void ConfirmAction()
    {
        if(attacking) 
        {
            if (friendlyCreature.GetTackleAp() <= 15)
            {
                Action("Tackle");
            }
            
        }   
    }
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
    public void TackleAPIncrease()
    {
        int increaseTackleAP = aPBoost.GetAPBoost();

        if(friendlyCreature.GetTackleAp() <= 15)
        {
            friendlyCreature.IncreasePlayerAP(increaseTackleAP);
            aPBoost.UseItem(1);
            UpdateAP();
        }

    }

    /// <summary>
    /// Combat Cycle Enumerators
    /// </summary>
    IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(2);
        EnemyAttacksPlayer();
        yield return new WaitForSeconds(2);
        BackToCombatOptions();
    }
    IEnumerator PlayerRanOutOfAP()
    {
        SwitchToCombatDialogue();
        PlayerRanOutOfTackleAP();
        yield return new WaitForSeconds(2);
        SwitchToFightPanel();
    }
}


