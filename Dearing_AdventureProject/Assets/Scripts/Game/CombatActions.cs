using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatActions : MonoBehaviour
{
    public static CombatActions Instance;

    private bool attacking;
    private bool playerDefending;
    private bool persuading;
    private bool mocking;
    private bool increasingTackleAP;
    private bool increasingPersuadeAP;
    private bool increasingMockAP;
    private bool usingPotion;
    private bool usingAPBoost;
    private int inflictedDamageToEnemy;
    private int inflictedModifiedDamageToPlayer;
    private int inflictedDamageToPlayer;

    public CombatActions()
    {
        Instance = this;
    }

    public void Tackle()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAP() != 0)
            {
                attacking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 0)
            {
                attacking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetTackleAP() != 0)
            {
                attacking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 0)
            {
                attacking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetTackleAP() != 0)
            {
                attacking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 0)
            {
                attacking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetTackleAP() != 0)
            {
                attacking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 0)
            {
                attacking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
    }

    public void Persuading()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() != 0)
            {
                persuading = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 0)
            {
                persuading = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() != 0)
            {
                persuading = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 0)
            {
                persuading = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() != 0)
            {
                persuading = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 0)
            {
                persuading = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() != 0)
            {
                persuading = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 0)
            {
                persuading = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
    }

    public void Mocking()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAP() != 0)
            {
                mocking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAP() == 0)
            {
                mocking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetMockAP() != 0)
            {
                mocking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetMockAP() == 0)
            {
                mocking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetMockAP() != 0)
            {
                mocking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetMockAP() == 0)
            {
                mocking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetMockAP() != 0)
            {
                mocking = true;
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetMockAP() == 0)
            {
                mocking = false;
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerRanOutOfAPDialogue());
            }
        }
    }

    public void RunAway()
    {
        if (GymBattleOneManager.Instance.ReturnBattleStatus() == true)
        {
            PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerTriedToRunAwayDialogue());
        }
    }

    public void Defend()
    {
        SwitchPanels.Instance.SwitchToConfirmPanel();
        playerDefending = true;
    }
    public void ConfirmPlayerAction()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (attacking)
            {
                if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAP() <= 15)
                {
                    Action("Tackle");
                }
            }
            else if (persuading)
            {
                if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() <= 10)
                {
                    Action("Persuade");
                }
            }
            if (mocking)
            {
                if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAP() <= 5)
                {
                    Action("Mock");
                }
            }
            else if (playerDefending)
            {
                Action("Defend");
            }
            if (usingPotion)
            {
                if (GymBattleOneManager.Instance.ReturnPotion().GetItemQuantity() > 0)
                {
                    Action("Potion");
                }
            }
            else if (usingAPBoost)
            {
                if (GymBattleOneManager.Instance.ReturnAPBoost().GetItemQuantity() > 0)
                {
                    Action("APBoost");
                }
            }
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (attacking)
            {
                if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetTackleAP() <= 20)
                {
                    Action("Tackle");
                }
            }
            else if (persuading)
            {
                if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() <= 15)
                {
                    Action("Persuade");
                }
            }
            if (mocking)
            {
                if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetMockAP() <= 10)
                {
                    Action("Mock");
                }
            }
            else if (playerDefending)
            {
                Action("Defend");
            }
            if (usingPotion)
            {
                if (GymBattleTwoManager.Instance.ReturnPotion().GetItemQuantity() > 0)
                {
                    Action("Potion");
                }
            }
            else if (usingAPBoost)
            {
                if (GymBattleTwoManager.Instance.ReturnAPBoost().GetItemQuantity() > 0)
                {
                    Action("APBoost");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (attacking)
            {
                if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetTackleAP() <= 25)
                {
                    Action("Tackle");
                }
            }
            else if (persuading)
            {
                if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() <= 20)
                {
                    Action("Persuade");
                }
            }
            if (mocking)
            {
                if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetMockAP() <= 15)
                {
                    Action("Mock");
                }
            }
            else if (playerDefending)
            {
                Action("Defend");
            }
            if (usingPotion)
            {
                if (GymBattleThreeManager.Instance.ReturnPotion().GetItemQuantity() > 0)
                {
                    Action("Potion");
                }
            }
            else if (usingAPBoost)
            {
                if (GymBattleThreeManager.Instance.ReturnAPBoost().GetItemQuantity() > 0)
                {
                    Action("APBoost");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (attacking)
            {
                if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetTackleAP() <= 30)
                {
                    Action("Tackle");
                }
            }
            else if (persuading)
            {
                if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() <= 25)
                {
                    Action("Persuade");
                }
            }
            if (mocking)
            {
                if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetMockAP() <= 20)
                {
                    Action("Mock");
                }
            }
            else if (playerDefending)
            {
                Action("Defend");
            }
            if (usingPotion)
            {
                if (GymBattleFourManager.Instance.ReturnPotion().GetItemQuantity() > 0)
                {
                    Action("Potion");
                }
            }
            else if (usingAPBoost)
            {
                if (GymBattleFourManager.Instance.ReturnAPBoost().GetItemQuantity() > 0)
                {
                    Action("APBoost");
                }
            }
        }
    }

    public void CancelPlayerAction()
    {
        if (attacking)
        {
            SwitchPanels.Instance.SwitchToFightPanel();
            attacking = false;
        }
        else if (persuading)
        {
            SwitchPanels.Instance.SwitchToFightPanel();
            persuading = false;
        }
        if (mocking)
        {
            SwitchPanels.Instance.SwitchToFightPanel();
            mocking = false;
        }
        else if (playerDefending)
        {
            SwitchPanels.Instance.BackToCombatOptions();
            playerDefending = false;
        }
        if (usingPotion)
        {
            SwitchPanels.Instance.SwitchToItemsPanel();
            usingPotion = false;
        }
        else if (usingAPBoost)
        {
            SwitchPanels.Instance.SwitchToItemsPanel();
            usingAPBoost = false;
        }
    }

    void Action(string input)
    {
        int accuracy = Random.Range(0, 20);

        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            switch (input)
            {
                case "Tackle":

                    if (accuracy >= 4)
                    {
                        
                        inflictedDamageToEnemy = GymBattleOneManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleOneManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleOneManager.Instance.UpdateHealthAndNameText();
                        GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                    }
                    else if (accuracy <= 3)
                    {
                        
                        GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerMissedTackle();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Persuade":

                    if (accuracy >= 7)
                    {
                        
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleOneManager.Instance.UpdateHealthAndNameText();
                        GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    else if (accuracy <= 6)
                    {
                        
                        persuading = false;
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotPersuade();
                        GymBattleOneManager.Instance.UpdateHealthAndNameText();
                        GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());
                    
                    break;

                case "Mock":

                    if (accuracy >= 12)
                    {
                        
                        inflictedDamageToEnemy = GymBattleOneManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleOneManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleOneManager.Instance.UpdateHealthAndNameText();
                        GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                    }
                    else if (accuracy <= 11)
                    {
                        
                        mocking = false;
                        GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotMock();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Defend":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerIsDefending();
                    StartCoroutine(EnemyAction());

                    break;

                case "Potion":

                    UsingItems.Instance.UsingPotion();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    StartCoroutine(EnemyAction());


                    break;


                case "APBoost":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    StartCoroutine(EnemyAction());

                    break;

            }
            
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {

            switch (input)
            {
                case "Tackle":

                    if (accuracy >= 7)
                    {
                        
                        inflictedDamageToEnemy = GymBattleTwoManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleTwoManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                        GymBattleTwoManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                    }
                    else if (accuracy <= 6)
                    {
                        
                        GymBattleTwoManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerMissedTackle();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Persuade":

                    if (accuracy >= 7)
                    {
                        
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                        GymBattleTwoManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    else if (accuracy <= 6)
                    {
                        
                        persuading = false;
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotPersuade();
                        GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                        GymBattleTwoManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());
                    
                    break;

                case "Mock":

                    if (accuracy >= 12)
                    {
                        
                        inflictedDamageToEnemy = GymBattleTwoManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleTwoManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                        GymBattleTwoManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                    }
                    else if (accuracy <= 11)
                    {
                        
                        mocking = false;
                        GymBattleTwoManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotMock();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Defend":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerIsDefending();
                    StartCoroutine(EnemyAction());

                    break;

                case "Potion":

                    UsingItems.Instance.UsingPotion();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                    StartCoroutine(EnemyAction());


                    break;


                case "APBoost":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    StartCoroutine(EnemyAction());

                    break;

            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {

            switch (input)
            {
                case "Tackle":

                    if (accuracy >= 7)
                    {

                        inflictedDamageToEnemy = GymBattleThreeManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleThreeManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                        GymBattleThreeManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                    }
                    else if (accuracy <= 6)
                    {

                        GymBattleThreeManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerMissedTackle();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Persuade":

                    if (accuracy >= 7)
                    {

                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                        GymBattleThreeManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    else if (accuracy <= 6)
                    {

                        persuading = false;
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotPersuade();
                        GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                        GymBattleThreeManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Mock":

                    if (accuracy >= 12)
                    {

                        inflictedDamageToEnemy = GymBattleThreeManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleThreeManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                        GymBattleThreeManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                    }
                    else if (accuracy <= 11)
                    {

                        mocking = false;
                        GymBattleThreeManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotMock();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Defend":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerIsDefending();
                    StartCoroutine(EnemyAction());

                    break;

                case "Potion":

                    UsingItems.Instance.UsingPotion();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                    StartCoroutine(EnemyAction());


                    break;


                case "APBoost":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    StartCoroutine(EnemyAction());

                    break;

            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {

            switch (input)
            {
                case "Tackle":

                    if (accuracy >= 7)
                    {

                        inflictedDamageToEnemy = GymBattleFourManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleFourManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleFourManager.Instance.UpdateHealthAndNameText();
                        GymBattleFourManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                    }
                    else if (accuracy <= 6)
                    {

                        GymBattleFourManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerMissedTackle();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Persuade":

                    if (accuracy >= 7)
                    {

                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleFourManager.Instance.UpdateHealthAndNameText();
                        GymBattleFourManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    else if (accuracy <= 6)
                    {

                        persuading = false;
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotPersuade();
                        GymBattleFourManager.Instance.UpdateHealthAndNameText();
                        GymBattleFourManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Mock":

                    if (accuracy >= 12)
                    {

                        inflictedDamageToEnemy = GymBattleFourManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                        GymBattleFourManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                        GymBattleFourManager.Instance.UpdateHealthAndNameText();
                        GymBattleFourManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                    }
                    else if (accuracy <= 11)
                    {

                        mocking = false;
                        GymBattleFourManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                        SwitchPanels.Instance.SwitchToCombatDialogue();
                        PlayerEnemyDialogue.Instance.PlayerCouldNotMock();
                    }
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    StartCoroutine(EnemyAction());

                    break;

                case "Defend":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerIsDefending();
                    StartCoroutine(EnemyAction());

                    break;

                case "Potion":

                    UsingItems.Instance.UsingPotion();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    GymBattleFourManager.Instance.UpdateHealthAndNameText();
                    StartCoroutine(EnemyAction());


                    break;


                case "APBoost":

                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    GymBattleFourManager.Instance.UpdateHealthAndNameText();
                    UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                    StartCoroutine(EnemyAction());

                    break;

            }
        }
    }

    public void IncreaseTackleAP()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAP() < 15)
            {
                UsingItems.Instance.SelectAPToIncrease("Tackle");
                increasingTackleAP = true;
            }
            else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 15)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetTackleAP() < 20)
            {
                UsingItems.Instance.SelectAPToIncrease("Tackle");
                increasingTackleAP = true;
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 20)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetTackleAP() < 25)
            {
                UsingItems.Instance.SelectAPToIncrease("Tackle");
                increasingTackleAP = true;
            }
            else if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 25)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetTackleAP() < 30)
            {
                UsingItems.Instance.SelectAPToIncrease("Tackle");
                increasingTackleAP = true;
            }
            else if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 30)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }

    }
    public void IncreasePersuadeAP()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() < 10)
            {
                UsingItems.Instance.SelectAPToIncrease("Persuade");
                increasingPersuadeAP = true;
            }
            else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 10)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() < 15)
            {
                UsingItems.Instance.SelectAPToIncrease("Persuade");
                increasingPersuadeAP = true;
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 15)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() < 20)
            {
                UsingItems.Instance.SelectAPToIncrease("Persuade");
                increasingPersuadeAP = true;
            }
            else if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 20)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() < 25)
            {
                UsingItems.Instance.SelectAPToIncrease("Persuade");
                increasingPersuadeAP = true;
            }
            else if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 25)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }

    }
    public void IncreaseMockAP()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAP() < 5)
            {
                UsingItems.Instance.SelectAPToIncrease("Mock");
                increasingMockAP = true;
            }
            else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAP() == 5)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetMockAP() < 10)
            {
                UsingItems.Instance.SelectAPToIncrease("Mock");
                increasingMockAP = true;
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetMockAP() == 10)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetMockAP() < 15)
            {
                UsingItems.Instance.SelectAPToIncrease("Mock");
                increasingMockAP = true;
            }
            else if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetMockAP() == 15)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetMockAP() < 15)
            {
                UsingItems.Instance.SelectAPToIncrease("Mock");
                increasingMockAP = true;
            }
            else if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetMockAP() == 15)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
            }
        }

    }

    void EnemyAttacksPlayer()
    {
        int enemyAccuracy = Random.Range(0,20);

        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (enemyAccuracy >= 6 && !playerDefending)
            {
                inflictedDamageToPlayer = GymBattleOneManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                GymBattleOneManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedDamageToPlayer);
                GymBattleOneManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            else if (enemyAccuracy >= 6 && playerDefending)
            {
                inflictedDamageToPlayer = GymBattleOneManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                inflictedModifiedDamageToPlayer = GymBattleOneManager.Instance.ReturnEnemyCreature().DoModifiedEnemyDamage();
                GymBattleOneManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedModifiedDamageToPlayer);
                GymBattleOneManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            if (enemyAccuracy <= 5)
            {
                PlayerEnemyDialogue.Instance.EnemyMisses();
            }
            SwitchPanels.Instance.SwitchToCombatDialogue();
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (enemyAccuracy >= 6 && !playerDefending)
            {
                inflictedDamageToPlayer = GymBattleTwoManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                GymBattleTwoManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedDamageToPlayer);
                GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            else if (enemyAccuracy >= 6 && playerDefending)
            {
                inflictedDamageToPlayer = GymBattleTwoManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                inflictedModifiedDamageToPlayer = GymBattleTwoManager.Instance.ReturnEnemyCreature().DoModifiedEnemyDamage();
                GymBattleTwoManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedModifiedDamageToPlayer);
                GymBattleTwoManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            if (enemyAccuracy <= 5)
            {
                PlayerEnemyDialogue.Instance.EnemyMisses();
            }
            SwitchPanels.Instance.SwitchToCombatDialogue();
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (enemyAccuracy >= 6 && !playerDefending)
            {
                inflictedDamageToPlayer = GymBattleThreeManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                GymBattleThreeManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedDamageToPlayer);
                GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            else if (enemyAccuracy >= 6 && playerDefending)
            {
                inflictedDamageToPlayer = GymBattleThreeManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                inflictedModifiedDamageToPlayer = GymBattleThreeManager.Instance.ReturnEnemyCreature().DoModifiedEnemyDamage();
                GymBattleThreeManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedModifiedDamageToPlayer);
                GymBattleThreeManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            if (enemyAccuracy <= 5)
            {
                PlayerEnemyDialogue.Instance.EnemyMisses();
            }
            SwitchPanels.Instance.SwitchToCombatDialogue();
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (enemyAccuracy >= 6 && !playerDefending)
            {
                inflictedDamageToPlayer = GymBattleFourManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                GymBattleFourManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedDamageToPlayer);
                GymBattleFourManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            else if (enemyAccuracy >= 6 && playerDefending)
            {
                inflictedDamageToPlayer = GymBattleFourManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
                inflictedModifiedDamageToPlayer = GymBattleFourManager.Instance.ReturnEnemyCreature().DoModifiedEnemyDamage();
                GymBattleFourManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedModifiedDamageToPlayer);
                GymBattleFourManager.Instance.UpdateHealthAndNameText();
                PlayerEnemyDialogue.Instance.EnemyHitPlayer();
            }
            if (enemyAccuracy <= 5)
            {
                PlayerEnemyDialogue.Instance.EnemyMisses();
            }
            SwitchPanels.Instance.SwitchToCombatDialogue();
        }
    }
    public void ResetActions()
    {
        attacking = false;
        playerDefending = false;
        persuading = false;
        mocking = false;
        usingPotion = false;
        usingAPBoost = false;
        increasingTackleAP = false;
        increasingPersuadeAP = false;
        increasingMockAP = false;
    }

    public bool ReturnAttacking()
    {
        return this.attacking;
    } 
    public bool ReturnPlayerDefending()
    {
        return this.playerDefending;
    }

    public bool ReturnPersuading()
    {
        return this.persuading;
    }
    public void SetAttackingBool(bool value)
    {
        attacking = value;
    }
    public bool ReturnMocking()
    {
        return this.mocking;
    }
    public bool ReturnUsingPotions()
    {
        return this.usingPotion;
    }
    public bool ReturnUsingAPBoost()
    {
        return this.usingAPBoost;
    }
    public bool ReturnIncreasingTackleAP()
    {
        return this.increasingTackleAP;
    }

    public bool ReturnIncreasingPersuadeAP()
    {
        return this.increasingPersuadeAP;
    }

    public bool ReturnIncreasingMockAP()
    {
        return this.increasingMockAP;
    }

    public int ReturnInflictedModifiedDamageToPlayer()
    {
        return this.inflictedModifiedDamageToPlayer;
    }

    public int ReturnInflictedDamageToPlayer()
    {
        return this.inflictedDamageToPlayer;
    }
    public int ReturnInflictedDamageToEnemy()
    {
        return this.inflictedDamageToEnemy;
    }

    public void SetPersuadingBool(bool value)
    {
        persuading = value;
    }

    public void SetMockingBool(bool value)
    {
        mocking = value;
    }

    public void SetUsingPotionsBool(bool value)
    {
        usingPotion = value;
    }

    public void SetUsingAPBoostBool(bool value)
    {
        usingAPBoost = value;
    }

    public void SetIncreasingTackleAP(bool value)
    {
        increasingTackleAP = value;
    }

    public void SetIncreasingPersuadeAPBool(bool value)
    {
        increasingPersuadeAP = value;
    }

    public void SetIncreasingMockAPBool(bool value)
    {
        increasingMockAP = value;
    }

    public IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(2.0f);

        if (attacking && !persuading && !mocking)
        {
            EnemyAttacksPlayer();
            yield return new WaitForSeconds(2.0f);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        else if (!attacking && !persuading && !mocking)
        {
            EnemyAttacksPlayer();
            yield return new WaitForSeconds(2.0f);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        if (!attacking && persuading && !mocking)
        {
            yield return new WaitForSeconds(2.0f);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        else if (!attacking && !persuading && mocking)
        {
            yield return new WaitForSeconds(2.0f);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        if (!attacking && playerDefending && !persuading && !mocking)
        {
            EnemyAttacksPlayer();
            yield return new WaitForSeconds(2.0f);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        PlayerEnemyDialogue.Instance.TurnOffText();
    }
}
