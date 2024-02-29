using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class script is in charge of giving the enemy in each level its data, Health/Level/Name
/// </summary>
public class EnemyCreature 
{
    private string enemyName;
    private int enemyHealth;
    private int level;
    private int enemyDamage;
    private int modifiedDamage;
    private bool evolved;
    


    private EnemyCreature(string enemyName, int health, int level,bool evolved)
    {
        this.enemyName = enemyName;
        this.enemyHealth = health;
        this.level = level;
        this.evolved = evolved;
        
    }
    public static EnemyCreature Create(string enemyName, int enemyHealth, int level,bool evolved)
    {
        return new EnemyCreature(enemyName, enemyHealth, level, evolved);
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
        }
    }

    public int GetEnemyHealth()
    {
        return this.enemyHealth;
    }
    public string GetEnemyName()
    {
        return this.enemyName;
    }
    public int DoEnemyDamage()
    {
        if(!evolved)
        {
            enemyDamage = Random.Range(2, 8);

            if (CombatActions.Instance.ReturnPlayerDefending() == true)
            {
                modifiedDamage = enemyDamage - 2;
            }
        }
        else if(evolved)
            
            enemyDamage = Random.Range(7, 15);

        if (CombatActions.Instance.ReturnPlayerDefending() == true)
        {
            modifiedDamage = enemyDamage - 5;
        }

        return this.enemyDamage;
    }
    public int DoModifiedEnemyDamage()
    {
        
        return this.modifiedDamage;
    }
    public int GetLevel()
    {
        return this.level;
    }
}
