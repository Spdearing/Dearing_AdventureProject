using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyCreature
{
    private string friendlyName;
    private int friendlyHealth;
    private int damage;



    private FriendlyCreature(string friendlyName, int friendlyHealth)
    {
        this.friendlyName = friendlyName;
        this.friendlyHealth = friendlyHealth;
       
    }

    public static FriendlyCreature Create(string friendlyName, int friendlyHealth)
    {
        return new FriendlyCreature(friendlyName, friendlyHealth);
    }

    public void TakeDamage(int damage)
    {
    
        this.friendlyHealth -= damage;

        if (this.friendlyHealth <= 0)
        {
            this.friendlyHealth = 0;
        }
    }

    public int GetFriendlyHealth()
    {
        return this.friendlyHealth;
    }
    public string GetFriendlyName()
    {
        return this.friendlyName;
    }
    public int DoPlayerDamage()
    {
        damage = Random.Range(2, 6);

        return this.damage;
    }
    public void Heal(int amount)
    {
        
        this.friendlyHealth += amount;
        
        if (this.friendlyHealth >= 10)
        {
            this.friendlyHealth = 10;
        }
    }
}
