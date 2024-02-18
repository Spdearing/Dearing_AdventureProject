using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyCreature
{
    private string friendlyName;
    private int friendlyHealth;
    private int damage;
    private int level;
    private string tackleName;
    private string persuadeName;
    private string mockName;
    private int tackleAp;
    private int persuadeAp;
    private int mockAp;



    private FriendlyCreature(string friendlyName, int friendlyHealth, int level, int tackleAp, int persuadeAp, int mockAp)
    {
        this.friendlyName = friendlyName;
        this.friendlyHealth = friendlyHealth;
        this.level = level;
        this.tackleAp = tackleAp;
        this.tackleAp = tackleAp;
        this.persuadeAp = persuadeAp;
        this.mockAp = mockAp;
    }

    public static FriendlyCreature Create(string friendlyName, int friendlyHealth, int level, int tackleAp, int persuadeAp, int mockAp)
    {
        return new FriendlyCreature(friendlyName, friendlyHealth, level, tackleAp,persuadeAp,mockAp);
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

    public int GetLevel() 
    {
        return this.level;
    }

    public int GetTackleAP()
    {
        return this.tackleAp;
    }

    public int GetPersuadeAP() 
    {
        return this.persuadeAp;
    }

    public int GetMockAP() 
    {
        return this.mockAp;
    }

    public string ReturnTackleName()
    {
        tackleName = "Tackle";
        return this.tackleName;        
    }
    public string ReturnPersuadeName() 
    {
        persuadeName = "Persuade";
        return this.persuadeName;
    }
    public string ReturnMockName()
    {
        mockName = "Mock";
        return this.mockName;
    }

    public int DoPlayerDamage()
    {
        int accuracy = Random.Range(0, 11);
        {
            if (accuracy <= 4) // if accuracy is 0,1,2,3, or 4  
            {
                damage = 2;
            }
            else if (accuracy >= 5 && accuracy <= 7) 
            {
                damage = 5;
            }
            if(accuracy >= 8)
            {
                damage = 8;
            }
        }
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
    public void IncreasePlayerAP(int amount)
    {
        if(CombatActions.Instance.ReturnIncreasingTackleAP() == true)
        {
            this.tackleAp += amount;

            if (this.tackleAp >= 15)
            {
                this.tackleAp = 15;
            }
        }
        else if(CombatActions.Instance.ReturnIncreasingPersuadeAP() == true)
        {
            {
                this.persuadeAp += amount;

                if (this.persuadeAp >= 15)
                {
                    this.persuadeAp = 15;
                }
            }
        }
        if(CombatActions.Instance.ReturnIncreasingMockAP() == true)
        {
            {
                this.mockAp += amount;

                if (this.mockAp >= 15)
                {
                    this.mockAp = 15;
                }
            }
        }
    
    }

    public void SpendTackleAP(int amount)
    {
        this.tackleAp -= amount;

        if(this.tackleAp <= 0)
        {
            this.tackleAp = 0;
        }
    }
    public void SpendPersuadeAP(int amount)
    {
        this.persuadeAp -= amount;
        
        if (this.persuadeAp <= 0)
        {
            this.persuadeAp = 0;
        }
    }
    public void SpendMockAP(int amount)
    {
        this.mockAp -= amount;

        if (this.mockAp <= 0)
        {
            this.mockAp = 0;
        }
    }
    public void APBoost(int amount) 
    { 
        this.tackleAp += amount;
        this.persuadeAp += amount;
        this.mockAp += amount;
    }
}
