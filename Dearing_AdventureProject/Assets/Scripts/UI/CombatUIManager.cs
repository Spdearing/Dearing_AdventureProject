using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    [SerializeField] GameObject mainCombatPanel;
    [SerializeField] GameObject attackPanel;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject ItemsPanel;

    

    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();
    
    
        
       
        


// Start is called before the first frame update
    void Start()
    {
        panels.Add("MainCombatPanel", mainCombatPanel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
