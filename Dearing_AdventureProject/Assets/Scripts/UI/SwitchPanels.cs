using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Handles the panel switching for each battles when you are making combat choices
/// </summary>

public class SwitchPanels: MonoBehaviour 
{
    public static SwitchPanels Instance;

    [SerializeField] GameObject combatDialoguePanel;
    [SerializeField] GameObject playerCombatOptions;
    [SerializeField] GameObject fightPanel;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject itemsPanel;
    [SerializeField] GameObject aPBoostSelectionPanel;

    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    public SwitchPanels()
    {
        Instance = this;
    }


    void Start()
    {
        panels.Add("CombatDialogue", combatDialoguePanel);
        panels.Add("PlayerCombatOptions", playerCombatOptions);
        panels.Add("FightPanel", fightPanel);
        panels.Add("ConfirmPanel", confirmPanel);
        panels.Add("ItemsPanel", itemsPanel);
        panels.Add("APBoosterSelectionPanel", aPBoostSelectionPanel);

        //The initial panel is the player options when the game begins.
        SwitchPanel("PlayerCombatOptions");
    }

    public void SwitchPanel(string panelName)
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

    public void Fight()
    {
        SwitchToFightPanel();
    }
    public void SwitchToFightPanel()
    {
        SwitchPanel("FightPanel");
    }
    public void SwitchToConfirmPanel()
    {
        SwitchPanel("ConfirmPanel");
    }
    public void SwitchToCombatDialogue()
    {
        SwitchPanel("CombatDialogue");
    }
    public void SwitchToItemsPanel()
    {
        SwitchPanel("ItemsPanel");
    }
    public void SwitchToAPBoosterSelectionPanel()
    {
        SwitchPanel("APBoosterSelectionPanel");
    }
    public void BackToCombatOptions()
    {
        SwitchPanel("PlayerCombatOptions");
    }
}
