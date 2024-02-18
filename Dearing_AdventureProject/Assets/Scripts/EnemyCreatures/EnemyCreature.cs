using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreature 
{
    private string enemyName;
    private int enemyHealth;
    private int level;
    private int enemyDamage;
    private int modifiedDamage;
    


    private EnemyCreature(string enemyName, int health, int level)
    {
        this.enemyName = enemyName;
        this.enemyHealth = health;
        this.level = level;
        
    }
    public static EnemyCreature Create(string enemyName, int enemyHealth, int level)
    {
        return new EnemyCreature(enemyName, enemyHealth, level);
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
        enemyDamage = Random.Range(2,8);

        if(CombatActions.Instance.ReturnPlayerDefending() == true)
        {
            modifiedDamage = enemyDamage - 2;
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
