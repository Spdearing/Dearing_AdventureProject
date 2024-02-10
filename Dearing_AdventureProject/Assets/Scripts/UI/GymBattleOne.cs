using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GymBattleOne : MonoBehaviour
{
    [SerializeField] GameObject mainCombatPanel;
    [SerializeField] GameObject fightPanel;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject ItemsPanel;

    private TMP_Text enemyName;
    private TMP_Text playerName;
    private TMP_Text enemyHealth;
    private TMP_Text playerHealth;

    private string playerCreatureName;
    private string enemyCreatureName;

    

    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        playerCreatureName = "Rextalion";
        enemyCreatureName = "Barnabus";
        enemyName = GameObject.Find("EnemyName").GetComponent<TMP_Text>();
        playerName = GameObject.Find("PlayerName").GetComponent<TMP_Text>();
        enemyHealth = GameObject.Find("EnemyHealth").GetComponent<TMP_Text>();
        playerHealth = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
        panels.Add("MainCombatPanel", mainCombatPanel);
        panels.Add("FightPanel", fightPanel);
        panels.Add("confirmPanel", confirmPanel);
        panels.Add("ItemsPanel", ItemsPanel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealthAndNameText()
    {
        playerName.text = "Player Name: " + playerCreatureName;
        
    }

}
