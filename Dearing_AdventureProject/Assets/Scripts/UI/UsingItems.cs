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
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            switch (ability)
            {
                case "Tackle":

                    int increaseTackleAP = GymBattleThreeManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleThreeManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseTackleAP);
                    GymBattleThreeManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleThreeManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Persuade":

                    int increasePersuadeAP = GymBattleThreeManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleThreeManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increasePersuadeAP);
                    GymBattleThreeManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleThreeManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Mock":

                    int increaseMockAP = GymBattleThreeManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleThreeManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseMockAP);
                    GymBattleThreeManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleThreeManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            switch (ability)
            {
                case "Tackle":

                    int increaseTackleAP = GymBattleFourManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleFourManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseTackleAP);
                    GymBattleFourManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleFourManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Persuade":

                    int increasePersuadeAP = GymBattleFourManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleFourManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increasePersuadeAP);
                    GymBattleFourManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleFourManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();

                    break;

                case "Mock":

                    int increaseMockAP = GymBattleFourManager.Instance.ReturnAPBoost().GetAPBoost();

                    GymBattleFourManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseMockAP);
                    GymBattleFourManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleFourManager.Instance.UpdateAP();
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
            if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() <= 19)
            {
                CombatActions.Instance.SetUsingPotionsBool(true);
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() == 20)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullHP());
            }
        }
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() <= 39)
            {
                CombatActions.Instance.SetUsingPotionsBool(true);
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleThreeManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() == 40)
            {
                PlayerEnemyDialogue.Instance.StartCoroutine(PlayerEnemyDialogue.Instance.PlayerHasFullHP());
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() <= 59)
            {
                CombatActions.Instance.SetUsingPotionsBool(true);
                SwitchPanels.Instance.SwitchToConfirmPanel();
            }
            else if (GymBattleFourManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() == 60)
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
        if (SceneManager.GetActiveScene().name == "GymBattleThree")
        {
            int healingAmount = GymBattleThreeManager.Instance.ReturnPotion().GetHealing();
            GymBattleThreeManager.Instance.ReturnFriendlyCreature().Heal(healingAmount);
            GymBattleThreeManager.Instance.ReturnPotion().UseItem(1);
            GymBattleThreeManager.Instance.UpdateInventory();
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleFour")
        {
            int healingAmount = GymBattleFourManager.Instance.ReturnPotion().GetHealing();
            GymBattleFourManager.Instance.ReturnFriendlyCreature().Heal(healingAmount);
            GymBattleFourManager.Instance.ReturnPotion().UseItem(1);
            GymBattleFourManager.Instance.UpdateInventory();
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
