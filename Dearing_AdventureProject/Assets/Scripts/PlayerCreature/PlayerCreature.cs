using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyCreature : MonoBehaviour
{
    private string friendlyName;
    private int friendlyHealth;
    private int damage;



    public FriendlyCreature(string friendlyName, int friendlyHealth)
    {
        this.friendlyName = friendlyName;
        this.friendlyHealth = friendlyHealth;
       
    }

    public void TakeDamage(int damage)
    {
        friendlyHealth -= damage;
        if (friendlyHealth <= 0)
        {
            friendlyHealth = 0;
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
}
