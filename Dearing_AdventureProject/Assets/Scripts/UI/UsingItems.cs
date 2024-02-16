using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingItems : MonoBehaviour
{
    public static UsingItems Instance;

    public UsingItems()
    {
        Instance = this;
    }

    public void SelectAPToIncrease(string ability)
    {
        switch(ability) 
        {
            case "Tackle":

            int increaseTackleAP = GymBattleOneManager.Instance.ReturnAPBoost().GetAPBoost();

                if(GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAp() <= 15)
                {
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseTackleAP);
                    GymBattleOneManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleOneManager.Instance.UpdateAP();
                    CombatActions.Instance.SetUsingAPBoostBool(true);
                    SwitchPanels.Instance.SwitchToConfirmPanel();
                }
                break;

            case "Persuade":

                int increasePersuadeAP = GymBattleOneManager.Instance.ReturnAPBoost().GetAPBoost();

                if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAp() <= 15)
                {
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increasePersuadeAP);
                    GymBattleOneManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleOneManager.Instance.UpdateAP();
                }
                break;

            case "Mock":

                int increaseMockAP = GymBattleOneManager.Instance.ReturnAPBoost().GetAPBoost();

                if (GymBattleOneManager.Instance.ReturnFriendlyCreature().GetTackleAp() <= 15)
                {
                    GymBattleOneManager.Instance.ReturnFriendlyCreature().IncreasePlayerAP(increaseMockAP);
                    GymBattleOneManager.Instance.ReturnAPBoost().UseItem(1);
                    GymBattleOneManager.Instance.UpdateAP();
                }
                break;

        }
    }
    public void UsePotion()
    {
        if(GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyHealth() <= 9)
        {
            CombatActions.Instance.SetUsingPotionsBool(true);
            SwitchPanels.Instance.SwitchToConfirmPanel();
        }
    }

    public void UsingPotion()
    {
        int healingAmount = GymBattleOneManager.Instance.ReturnPotion().GetHealing();
        GymBattleOneManager.Instance.ReturnFriendlyCreature().Heal(healingAmount);
        GymBattleOneManager.Instance.ReturnPotion().UseItem(1);
        GymBattleOneManager.Instance.UpdateInventory();
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
            yield return new WaitForSeconds(3);
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
