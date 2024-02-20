using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsingItems : MonoBehaviour
{
    public static UsingItems Instance;

    public UsingItems()
    {
        Instance = this;
    }

    public void SelectAPToIncrease(string ability)
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            switch (ability)
            {
                case "Tackle":

                    int increaseTackleAP = GymBattleOneManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleOneManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseTackleAP);
                    GymBattleOneManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleOneManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Persuade":

                    int increasePersuadeAP = GymBattleOneManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleOneManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increasePersuadeAP);
                    GymBattleOneManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleOneManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Mock":

                    int increaseMockAP = GymBattleOneManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleOneManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseMockAP);
                    GymBattleOneManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleOneManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            switch (ability)
            {
                case "Tackle":

                    int increaseTackleAP = GymBattleTwoManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleTwoManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseTackleAP);
                    GymBattleTwoManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleTwoManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Persuade":

                    int increasePersuadeAP = GymBattleTwoManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleTwoManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increasePersuadeAP);
                    GymBattleTwoManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleTwoManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Mock":

                    int increaseMockAP = GymBattleTwoManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleTwoManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseMockAP);
                    GymBattleTwoManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleTwoManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

            }
        }
    }
    
        
    public void UsePotion()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() <= 9)
            {
                CombatActions.Instance.SetUsingPotionsBool(true);
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() == 10)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullHP());
            }
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() <= 9)
            {
                CombatActions.Instance.SetUsingPotionsBool(true);
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() == 10)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullHP());
            }
        }

    }

    public void UsingPotion()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            int healingAmount = GymBattleOneManager.Instance.ReturnPotion().GetHealing();
            GymBattleOneManager.Instance.ReturnFriendlyCreature().Heal(healingAmount);
            GymBattleOneManager.Instance.ReturnPotion().UseItem(1);
            GymBattleOneManager.Instance.UpdateInventory();
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            int healingAmount = GymBattleTwoManager.Instance.ReturnPotion().GetHealing();
            GymBattleTwoManager.Instance.ReturnFriendlyCreature().Heal(healingAmount);
            GymBattleTwoManager.Instance.ReturnPotion().UseItem(1);
            GymBattleTwoManager.Instance.UpdateInventory();
        } 
    }
    public void UseAPBooster()
    {
        SwitchPanels.Instance.SwitchToAPBoosterSelectionPanel();
    }

    public IEnumerator UsingItem()
    {
        if (CombatActions.Instance.ReturnUsingPotions() == true)
        {
            PlayerEnemyDialogue.Instance.UsePotionText();
            SwitchPanels.Instance.SwitchToCombatDialogue();
            yield return new WaitForSeconds(2);
        }
        else if (CombatActions.Instance.ReturnUsingAPBoost() == true)
        {
            PlayerEnemyDialogue.Instance.UseAPBoostText();
            SwitchPanels.Instance.SwitchToCombatDialogue();
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(2);
    }
}
