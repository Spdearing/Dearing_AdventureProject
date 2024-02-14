using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActions : MonoBehaviour
{
    public static CombatActions Instance;

    private bool attacking;
    private bool persuading;
    private bool mocking;
    private bool usingPotion;
    private bool usingAPBoost;
    private int inflictedDamageToEnemy;
    private int inflictedDamageToPlayer;

    public CombatActions() 
    { 
        Instance = this;
    }

    public void Tackle()
    {
        Debug.Log(GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAp());


        if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAp() != 0)
        {
            attacking = true;
            SwitchPanels.Instance.SwitchToConfirmPanel();
        }
        else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAp() == 0)
        {
            attacking = false;
            PlayerEnemyDialogue.Instance.PlayerRanOutOfAPText();
        }
    }

    public void Persuading()
    {
        if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAp() != 0)
        {
            persuading = true;
            SwitchPanels.Instance.SwitchToConfirmPanel();
        }
        else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAp() == 0)
        {
            persuading = false;
            PlayerEnemyDialogue.Instance.PlayerRanOutOfAPText();
        }
    }

    public void Mocking()
    {
        if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAp() != 0)
        {
            mocking = true;
            SwitchPanels.Instance.SwitchToConfirmPanel();
        }
        else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAp() == 0)
        {
            mocking = false;
            PlayerEnemyDialogue.Instance.PlayerRanOutOfAPText();
        }
    }
    public void ConfirmPlayerAction()
    {
        if (attacking)
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAp() <= 15)
            {
                Action("Tackle");
            }
        }
        else if (persuading)
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetPersuadeAp() <= 10)
            {
                Action("Persuade");
            }
        }
        if (mocking)
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetMockAp() <= 5)
            {
                Action("Mock");
            }
        }
        else if (usingPotion)
        {
            if (GymBattleOneManager.Instance.ReturnPotion().GetItemQuantity() > 0)
            {
                Action("Potion");
            }
        }
        if (usingAPBoost)
        {
            if (GymBattleOneManager.Instance.ReturnAPBoost().GetItemQuantity() > 0)
            {
                Action("APBoost");
            }
        }
    }

    void Action(string input)
    {
        int accuracy = Random.Range(0, 11);

        switch (input)
        {
            case "Tackle":

                if (accuracy >= 5)
                {
                    inflictedDamageToEnemy = GymBattleOneManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                    GymBattleOneManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                }
                else if (accuracy <= 4)
                {
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendTackleAP(1);
                    PlayerEnemyDialogue.Instance.PlayerMissedTackle();
                }
                SwitchPanels.Instance.SwitchToCombatDialogue();
                StartCoroutine(EnemyAction());

                break;

            case "Persuade":

                if (accuracy >= 5)
                {
                    PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                }
                else if (accuracy <= 4)
                {
                    persuading = false;
                    PlayerEnemyDialogue.Instance.PlayerCouldNotPersuade();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendPersuadeAP(1);
                }
                SwitchPanels.Instance.SwitchToCombatDialogue();
                StartCoroutine(EnemyAction());
                Debug.Log(accuracy);
                break;

            case "Mock":

                if (accuracy >= 5)
                {
                    inflictedDamageToEnemy = GymBattleOneManager.Instance.ReturnFriendlyCreature().DoPlayerDamage();
                    GymBattleOneManager.Instance.ReturnEnemyCreature().TakeDamage(inflictedDamageToEnemy);
                    PlayerEnemyDialogue.Instance.PlayerHitEnemy();
                    GymBattleOneManager.Instance.UpdateHealthAndNameText();
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                }
                else if (accuracy <= 4)
                {
                    mocking = false;
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().SpendMockAP(1);
                    PlayerEnemyDialogue.Instance.PlayerCouldNotMock();
                }
                SwitchPanels.Instance.SwitchToCombatDialogue();
                StartCoroutine(EnemyAction());

                break;

            case "Potion":

                Debug.Log("about to use a potion");
                UsingItems.Instance.UsingPotion();
                Debug.Log("Starting the using item coroutine");
                UsingItems.Instance.StartCoroutine(UsingItems.Instance.UsingItem());
                Debug.Log("Did the itemCoroutine");
                GymBattleOneManager.Instance.UpdateHealthAndNameText();
                StartCoroutine(EnemyAction());
                

                break;


            case "APBoost":

                SwitchPanels.Instance.SwitchToCombatDialogue();
                GymBattleOneManager.Instance.UpdateHealthAndNameText();
                UsingItems.Instance.UsingItem();
                StartCoroutine(EnemyAction());

                break;

        }
    }

    public void IncreaseTackleAP()
    {
        UsingItems.Instance.SelectAPToIncrease("Tackle");
    }
    public void IncreasePersuadeAP()
    {
        UsingItems.Instance.SelectAPToIncrease("Persuade");
    }
    public void IncreaseMockAP()
    {
        UsingItems.Instance.SelectAPToIncrease("Mock");
    }

    void EnemyAttacksPlayer()
    {
        int enemyAccuracy = Random.Range(0, 5);

        if (enemyAccuracy >= 2)
        {
            inflictedDamageToPlayer = GymBattleOneManager.Instance.ReturnEnemyCreature().DoEnemyDamage();
            GymBattleOneManager.Instance.ReturnFriendlyCreature().TakeDamage(inflictedDamageToPlayer);
            GymBattleOneManager.Instance.UpdateHealthAndNameText();
            PlayerEnemyDialogue.Instance.EnemyHitPlayer();
        }
        else if (enemyAccuracy <= 1)
        {
            PlayerEnemyDialogue.Instance.EnemyMisses();
        }
        SwitchPanels.Instance.SwitchToCombatDialogue();
    }

    IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(2);
        if (attacking && !persuading && !mocking)
        {
            EnemyAttacksPlayer();
            yield return new WaitForSeconds(2);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        else if(!attacking && !persuading && !mocking)
        {
            EnemyAttacksPlayer();
            yield return new WaitForSeconds(2);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        if(!attacking && persuading && !mocking)
        {
            yield return new WaitForSeconds(2);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
        else if(!attacking && !persuading && mocking)
        {
            yield return new WaitForSeconds(2);
            SwitchPanels.Instance.BackToCombatOptions();
            ResetActions();
        }
    }

    void ResetActions()
    {
        attacking = false;
        persuading = false;
        mocking = false;
        usingPotion = false;
        usingAPBoost = false;
    }

    public bool ReturnAttacking()
    {
        return this.attacking;
    }
    public void SetAttackingBool(bool value)
    {
        attacking = value;
    }



    public bool ReturnPersuading()
    {
        return this.persuading;
    }
    public void SetPersuadingBool(bool value)
    {
        persuading = value;
    }


    public bool ReturnMocking()
    {
        return this.mocking;
    }
    public void SetMockingBool(bool value)
    {
        mocking = value;
    }


    public bool ReturnUsingPotions()
    {
        return this.usingPotion;
    }
    public void SetUsingPotionsBool(bool value)
    {
        usingPotion = value;
    }


    public bool ReturnUsingAPBoost()
    {
        return this.usingAPBoost;
    }
    public void SetUsingAPBoostBool(bool value)
    {
        usingAPBoost = value;
    }


    public int ReturnInflictedDamageToPlayer()
    {
        return this.inflictedDamageToPlayer;
    }
    public int ReturnInflictedDamageToEnemy()
    {
        return this.inflictedDamageToEnemy;
    }
}
