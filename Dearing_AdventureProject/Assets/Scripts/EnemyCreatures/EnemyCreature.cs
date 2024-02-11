using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreature 
{
    private string enemyName;
    private int enemyHealth;
    private int enemyDamage;
    


    private EnemyCreature(string enemyName, int health)
    {
        this.enemyName = enemyName;
        this.enemyHealth = health;
        
    }
    public static EnemyCreature Create(string enemyName, int enemyHealth)
    {
        return new EnemyCreature(enemyName, enemyHealth);
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
        enemyDamage = Random.Range(2, 6);

        return this.enemyDamage;
    }
}
