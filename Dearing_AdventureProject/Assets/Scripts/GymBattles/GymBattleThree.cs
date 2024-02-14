using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GymBattleThree : MonoBehaviour
{
    [SerializeField] GameObject mainCombatPanel;
    [SerializeField] GameObject fightPanel;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject ItemsPanel;

    private TMP_Text enemyName;
    private TMP_Text playerName;
    private TMP_Text enemyHealth;
    private TMP_Text playerHealth;

    

    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        enemyName = GameObject.Find("EnemyName").GetComponent<TMP_Text>();
        playerName = GameObject.Find("PlayerName").GetComponent<TMP_Text>();
        enemyHealth = GameObject.Find("EnemyHealth").GetComponent<TMP_Text>();
        playerHealth = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
        panels.Add("MainCombatPanel", mainCombatPanel);
        panels.Add("FightPanel", fightPanel);
        panels.Add("confirmPanel", confirmPanel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealthText()
    {

    }

}
