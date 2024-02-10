using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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


    //private string playerMisses = "Friendly Creature missed the enemy";
    //private string playerHitTarget = "Friendly player hit";
    //private string enemyHitPlayer = "Friendly c"


    private TMP_Text enemyName;
    private TMP_Text friendlyName;
    private TMP_Text enemyHealth;
    private TMP_Text friendlyHealth;
    private TMP_Text combatText;

    private EnemyCreature enemyCreature;
    private FriendlyCreature friendlyCreature;

    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        enemyCreature = new EnemyCreature("Barnabus", 10);
        friendlyCreature = new FriendlyCreature("Rexasourus", 10);
        enemyName = GameObject.Find("EnemyName").GetComponent<TMP_Text>();
        friendlyName = GameObject.Find("PlayerName").GetComponent<TMP_Text>();
        enemyHealth = GameObject.Find("EnemyHealth").GetComponent<TMP_Text>();
        friendlyHealth = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
        combatText = GameObject.Find("CombatText").GetComponent<TMP_Text>();
        panels.Add("CombatDialogue", combatDialoguePanel);//panels(0)
        panels.Add("PlayerCombatOptions", playerCombatOptions);//panels(1)
        panels.Add("FightPanel", fightPanel);//panels(2)
        panels.Add("confirmPanel", confirmPanel);//panels(3)
        panels.Add("ItemsPanel", ItemsPanel);//panels(4)

        SwitchPanel("PlayerCombatOptions");

    }
    // Update is called once per frame
    void Update()
    {
        UpdateHealthAndNameText();
    }

    void UpdateHealthAndNameText()
    {
        enemyName.text = "EnemyName: " + enemyCreature.GetEnemyName();
        enemyHealth.text = "HP: " + enemyCreature.GetEnemyHealth() + "/10";
        friendlyName.text = "FriendlyName: " + friendlyCreature.GetFriendlyName();
        friendlyHealth.text = "HP: " + friendlyCreature.GetFriendlyHealth() + "/10";
    }

    public void Fight()
    {
        SwitchToFightPanel();
        attacking = true;
    }

    public void Tackle()
    {
        SwitchToConfirmPanel();
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
                }
                else if (accuracy <=1 )
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

    public void ConfirmAction()
    {
        Action("Tackle");
    }

    IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(2);
        EnemyAttacksPlayer();
        yield return new WaitForSeconds(4);
        BackToCombatOptions();
    }
}


