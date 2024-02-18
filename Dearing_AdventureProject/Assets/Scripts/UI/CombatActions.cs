using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Persuading()
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

    public void Mocking()
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

    public void RunAway()
    {
        if(GymBattleOneManager.Instance.ReturnBattleStatus() == true)
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
        else if(playerDefending)
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

        switch (input)
        {
            case "Tackle":

                if (accuracy >= 10)
                {
                    Debug.Log("Hit Tackle");
                    inflictedDamageToEnemy = GymBattleOneManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                    GymBattleOneManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                }
                else if (accuracy <= 9)
                {
                    Debug.Log("Missed Tackle");
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerMissedTackle();
                }
                SwitchPanels.Instance.SwitchToCombatDialogue();
                StartCoroutine(EnemyAction());

                break;

            case "Persuade":

                if (accuracy >= 10)
                {
                    Debug.Log("Hit Persuade");
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                }
                else if (accuracy <= 9)
                {
                    Debug.Log("Missed Persuade");
                    persuading = false;
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerCouldNotPersuade();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                }
                SwitchPanels.Instance.SwitchToCombatDialogue();
                StartCoroutine(EnemyAction());
                Debug.Log(accuracy);
                break;

            case "Mock":

                if (accuracy >= 15)
                {
                    Debug.Log("Hit mock");
                    inflictedDamageToEnemy = GymBattleOneManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                    GymBattleOneManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                    SwitchPanels.Instance.SwitchToCombatDialogue();
                    PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                }
                else if (accuracy <= 14)
                {
                    Debug.Log("missed mock");
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

    public void IncreaseTackleAP()
    {
        if(GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAP() < 15)
        {
            UsingItems.Instance.SelectAPToIncrease("Tackle");
            increasingTackleAP = true;
        }
        else if(GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAP() == 15)
        {
            PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
        }
    }
    public void IncreasePersuadeAP()
    {
        if(GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() < 10)
        {
            UsingItems.Instance.SelectAPToIncrease("Persuade");
            increasingPersuadeAP = true;
        }
        else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAP() == 10)
        {
            PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
        }
    }
    public void IncreaseMockAP()
    {
        if(GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAP() < 5)
        {
            UsingItems.Instance.SelectAPToIncrease("Mock");
            increasingMockAP = true;
        }
        else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAP() == 5)
        {
            PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullAP());
        }
    }

    void EnemyAttacksPlayer()
    {
        int enemyAccuracy = Random.Range(0,20);

        if (enemyAccuracy >= 10 && !playerDefending)
        {
            inflictedDamageToPlayer = GymBattleOneManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
            GymBattleOneManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedDamageToPlayer);
            GymBattleOneManager.Instance.UpdateHealthAndNameText();
            PlayerEnemyDialogue.Instance.EnemyHitPlayer();
        }
        else if (enemyAccuracy >= 10 && playerDefending)
        {
            inflictedDamageToPlayer = GymBattleOneManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
            inflictedModifiedDamageToPlayer = GymBattleOneManager.Instance.ReturnEnemyCreature().DoModifiedEnemyDamage();
            GymBattleOneManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedModifiedDamageToPlayer);
            GymBattleOneManager.Instance.UpdateHealthAndNameText();
            PlayerEnemyDialogue.Instance.EnemyHitPlayer();
        }
        if (enemyAccuracy <= 9)
        {
            PlayerEnemyDialogue.Instance.EnemyMisses();
        }
        SwitchPanels.Instance.SwitchToCombatDialogue();
    }

    void ResetActions()
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

    IEnumerator EnemyAction()
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
