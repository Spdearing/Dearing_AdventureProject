using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEnemyDialogue : MonoBehaviour
{
    public static PlayerEnemyDialogue Instance;


    [SerializeField] TMP_Text combatText;

    public void Start()
    {
        combatText = GameObject.Find("CombatText").GetComponent<TMP_Text>();
        
    }

    public PlayerEnemyDialogue()
    {
        Instance = this;
    }

    public void PlayerMissedTackle()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (CombatActions.Instance.ReturnAttacking())
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " missed their tackle on " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName();
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (CombatActions.Instance.ReturnAttacking())
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " missed their tackle on " + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName();
            }
        }
    }

    public void PlayerCouldNotPersuade()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (CombatActions.Instance.ReturnPersuading() == false)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " failed to persuade " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName();
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (CombatActions.Instance.ReturnPersuading() == false)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " failed to persuade " + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName();
            }
        }
    }

    public void PlayerCouldNotMock()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (CombatActions.Instance.ReturnMocking() == false)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did not care about " + GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + "insults, TRY HARDER!";
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (CombatActions.Instance.ReturnMocking() == false)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did not care about " + GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + "insults, TRY HARDER!";
            }
        }

    }

    public void PlayerHitEnemy()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (CombatActions.Instance.ReturnAttacking() == true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToEnemy().ToString() + " to " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName();
            }
            else if (CombatActions.Instance.ReturnPersuading() == true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " persuaded " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " to not attack them";
            }
            if (CombatActions.Instance.ReturnMocking() == true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " mocked " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " into attacking themselves, dealing " + CombatActions.Instance.ReturnInflictedDamageToEnemy().ToString() + " points of damage";
            }
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (CombatActions.Instance.ReturnAttacking() == true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToEnemy().ToString() + " to " + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName();
            }
            else if (CombatActions.Instance.ReturnPersuading() == true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " persuaded " + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " to not attack them";
            }
            if (CombatActions.Instance.ReturnMocking() == true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " mocked " + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " into attacking themselves, dealing " + CombatActions.Instance.ReturnInflictedDamageToEnemy().ToString() + " points of damage";
            }
        }
    }

    public void EnemyMisses()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            combatText.text = GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " missed an attack on " + GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName();
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            combatText.text = GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " missed an attack on " + GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName();
        }
     
    }

    public void EnemyHitPlayer()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (CombatActions.Instance.ReturnPlayerDefending() != true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToPlayer().ToString() + " to " + GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName();
            }
            else if (CombatActions.Instance.ReturnPlayerDefending() == true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToPlayer().ToString() + " to " + GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + ". But because they chose to defend this turn" + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " only did " + CombatActions.Instance.ReturnInflictedModifiedDamageToPlayer() + " points of damage instead.";
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (CombatActions.Instance.ReturnPlayerDefending() != true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToPlayer().ToString() + " to " + GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName();
            }
            else if (CombatActions.Instance.ReturnPlayerDefending() == true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " did " + CombatActions.Instance.ReturnInflictedDamageToPlayer().ToString() + " to " + GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + ". But because they chose to defend this turn" + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " only did " + CombatActions.Instance.ReturnInflictedModifiedDamageToPlayer() + " points of damage instead.";
            }
        }


    }

    public void PlayerIsDefending()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " decided to defend themselves against " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + "'s next attack.";
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " decided to defend themselves against " + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + "'s next attack.";
        }

        
    }

    public void UsePotionText()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " healed themselves for " + GymBattleOneManager.Instance.ReturnPotion().GetHealing() + " points of HP!";
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " healed themselves for " + GymBattleTwoManager.Instance.ReturnPotion().GetHealing() + " points of HP!";
        }
        
    }
    public void UseAPBoostText()
    {
        if (SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            if (CombatActions.Instance.ReturnIncreasingTackleAP() == true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " increased their " + GymBattleOneManager.Instance.ReturnFriendlyCreature().ReturnTackleName() + " attack points.";
            }
            else if (CombatActions.Instance.ReturnIncreasingPersuadeAP() == true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " increased their " + GymBattleOneManager.Instance.ReturnFriendlyCreature().ReturnPersuadeName() + " attack points.";
            }
            if (CombatActions.Instance.ReturnIncreasingMockAP() == true)
            {
                combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " increased their " + GymBattleOneManager.Instance.ReturnFriendlyCreature().ReturnMockName() + " attack points.";
            }
        }
        else if (SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            if (CombatActions.Instance.ReturnIncreasingTackleAP() == true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " increased their " + GymBattleTwoManager.Instance.ReturnFriendlyCreature().ReturnTackleName() + " attack points.";
            }
            else if (CombatActions.Instance.ReturnIncreasingPersuadeAP() == true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " increased their " + GymBattleTwoManager.Instance.ReturnFriendlyCreature().ReturnPersuadeName() + " attack points.";
            }
            if (CombatActions.Instance.ReturnIncreasingMockAP() == true)
            {
                combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " increased their " + GymBattleTwoManager.Instance.ReturnFriendlyCreature().ReturnMockName() + " attack points.";
            }
        }


    }

    public void PlayerRanOutOfAPText()
    {
        combatText.text = "You cannot use that move, you ran out of AP.";
    }
    public void PlayerTriedToRunAwayText()
    {
        combatText.text = "You cannot run away, you are in the middle of gym battle!";
    }
    public void TurnOffText()
    {
        combatText.text = " ";
    }

    public IEnumerator PlayerHasFullAP()
    {
        SwitchPanels.Instance.SwitchToCombatDialogue();
        combatText.text = " Player cannot increase their AP any further!";
        yield return new WaitForSeconds(2);
        TurnOffText();
        SwitchPanels.Instance.SwitchToAPBoosterSelectionPanel();
    }
    public IEnumerator PlayerHasFullHP()
    {
        SwitchPanels.Instance.SwitchToCombatDialogue();
        combatText.text = " Player cannot increase their HP any further!";
        yield return new WaitForSeconds(2);
        TurnOffText();
        SwitchPanels.Instance.SwitchToItemsPanel();
    }
    public IEnumerator PlayerRanOutOfAPDialogue()
    {
        SwitchPanels.Instance.SwitchToCombatDialogue();
        PlayerRanOutOfAPText();
        yield return new WaitForSeconds(2);
        SwitchPanels.Instance.SwitchToFightPanel();
        TurnOffText();
    }
    public IEnumerator PlayerTriedToRunAwayDialogue()
    {
        SwitchPanels.Instance.SwitchToCombatDialogue();
        PlayerTriedToRunAwayText();
        yield return new WaitForSeconds(2);
        SwitchPanels.Instance.BackToCombatOptions();
        TurnOffText();
    }
    public IEnumerator PlayerDiedDialogue()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            yield return new WaitForSeconds(1);
            SwitchPanels.Instance.SwitchToCombatDialogue();
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " has fainted.... ";
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Gym");
            TurnOffText();
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo")
        {
            yield return new WaitForSeconds(1);
            SwitchPanels.Instance.SwitchToCombatDialogue();
            combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " has fainted.... ";
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Gym");
            TurnOffText();
        }

    }
    public IEnumerator PlayerWonTheBattleDialogue()
    {
        if(SceneManager.GetActiveScene().name == "GymBattleOne")
        {
            yield return new WaitForSeconds(1);
            SwitchPanels.Instance.SwitchToCombatDialogue();
            combatText.text = GymBattleOneManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " defeated " + GymBattleOneManager.Instance.ReturnEnemyCreature().GetEnemyName() + " Congradulations, you won the battle!!!";
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Gym");
            TurnOffText();
        }
        else if(SceneManager.GetActiveScene().name == "GymBattleTwo") 
        {
            yield return new WaitForSeconds(1);
            SwitchPanels.Instance.SwitchToCombatDialogue();
            combatText.text = GymBattleTwoManager.Instance.ReturnFriendlyCreature().GetFriendlyName() + " defeated " + GymBattleTwoManager.Instance.ReturnEnemyCreature().GetEnemyName() + " Congradulations, you won the battle!!!";
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Gym");
            TurnOffText();
        }
   
    }
  
}
