using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    [SerializeField] GameObject mainCombatPanel;
    [SerializeField] GameObject fightPanel;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject ItemsPanel;

    

    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        panels.Add("MainCombatPanel", mainCombatPanel);
        panels.Add("FightPanel", fightPanel);
        panels.Add("confirmPanel")
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
