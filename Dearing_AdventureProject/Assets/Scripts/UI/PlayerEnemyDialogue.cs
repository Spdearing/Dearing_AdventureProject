using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEnemyDialogue : MonoBehaviour
{
    public static PlayerEnemyDialogue Instance;


    private TMP_Text combatText;

    public void Start()
    {
        combatText = GameObject.Find("Combat").GetComponent<TMP_Text>();
    }

    public PlayerEnemyDialogue()
    {
        Instance = this;
    }

    public void PlayerMisses()
    {
        if (CombatActions.Instance.ReturnAttacking())
        {
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " missed their tackle on " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName();
        }
        else if (CombatActions.Instance.ReturnPersuading())
        {
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " failed to persuade " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName();
        }
        if (CombatActions.Instance.ReturnMocking())
        {
            combatText.text = GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did not care about " + GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + "insults, TRY HARDER!";
        }

    }

    public void PlayerHitEnemy()
    {
        if (CombatActions.Instance.ReturnAttacking())
        {
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToEnemy().ToString() + " to " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName();
        }
        else if (CombatActions.Instance.ReturnPersuading())
        {
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " persuaded " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " to not attack them";
        }
        if (CombatActions.Instance.ReturnMocking())
        {
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " mocked " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " into attacking themselves, dealing " + CombatActions.Instance.ReturnInflictedDamageToEnemy().ToString() + " points of damage";
        }

    }

    public void EnemyMisses()
    {
        combatText.text = GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " missed an attack on " + GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName();
    }

    public void EnemyHitPlayer()
    {
        combatText.text = GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToPlayer().ToString() + " to " + GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName();
    }

    public void UsePotionText()
    {
        combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " healed themselves for " + GymBattleOneManager.Instance.ReturnPotion().GetHealing() + " points of HP!";
    }
    public void UseAPBoostText()
    {
        combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " increased their AP for one of their abilities";
    }

    public void PlayerRanOutOfAPText()
    {
        combatText.text = "You cannot use that move, you ran out of AP.";
    }

    public void PlayerRanOutOfAP()
    {
        PlayerEnemyDialogue.Instance.PlayerRanOutOfAP();
    }

    public IEnumerator PlayerRanOutOfAPDialogue()
    {
        SwitchPanels.Instance.SwitchToCombatDialogue();
        PlayerRanOutOfAPText();
        yield return new WaitForSeconds(2);
        SwitchPanels.Instance.SwitchToFightPanel();
    }


}