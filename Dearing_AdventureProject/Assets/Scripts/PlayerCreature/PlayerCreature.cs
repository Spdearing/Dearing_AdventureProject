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
    private bool evolved;



    private FriendlyCreature(string friendlyName, int friendlyHealth, int level, int tackleAp, int persuadeAp, int mockAp, bool evolved)
    {
        this.friendlyName = friendlyName;
        this.friendlyHealth = friendlyHealth;
        this.level = level;
        this.tackleAp = tackleAp;
        this.tackleAp = tackleAp;
        this.persuadeAp = persuadeAp;
        this.mockAp = mockAp;
        this.evolved = evolved;
    }

    public static FriendlyCreature Create(string friendlyName, int friendlyHealth, int level, int tackleAp, int persuadeAp, int mockAp, bool evolved)
    {
        return new FriendlyCreature(friendlyName, friendlyHealth, level, tackleAp,persuadeAp,mockAp,evolved);
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
        int accuracy = Random.Range(1, 16);
        {
            if(!evolved)
            {
                if (accuracy <= 6)
                {
                    damage = 5;
                }
                else if (accuracy >= 5 && accuracy <= 10)
                {
                    damage = 8;
                }
                if (accuracy >= 12)
                {
                    damage = 10;
                }
            }
            else if(evolved) 
            {
                if (accuracy <= 6)
                {
                    damage = 10;
                }
                else if (accuracy >= 5 && accuracy <= 9)
                {
                    damage = 15;
                }
                if (accuracy >= 12)
                {
                    damage = 20;
                }
            }
       
        }
        return this.damage;
    }
    public void Heal(int amount)
    {
        
        this.friendlyHealth += amount;
        
        if (this.friendlyHealth >= 10 && this.level == 5)
        {
            this.friendlyHealth = 10;
        }
        else if (this.friendlyHealth >= 20 && this.level == 10)
        {
            this.friendlyHealth = 20;
        }
        if (this.friendlyHealth >= 40 && this.level == 20)
        {
            this.friendlyHealth = 40;
        }
        else if (this.friendlyHealth >= 60 && this.level == 30)
        {
            this.friendlyHealth = 60;
        }
    }
    public void IncreasePlayerAP(int amount)
    {
        if(CombatActions.Instance.ReturnIncreasingTackleAP() == true)
        {
            this.tackleAp += amount;

            if (this.tackleAp >= 15 && level == 5)
            {
                this.tackleAp = 15;
            }
            else if (this.tackleAp >= 20 && level == 10)
            {
                this.tackleAp = 20;
            }
            if (this.tackleAp >= 25 && level == 20)
            {
                this.tackleAp = 25;
            }
            else if (this.tackleAp >= 30 && level == 30)
            {
                this.tackleAp = 30;
            }
        }
        else if(CombatActions.Instance.ReturnIncreasingPersuadeAP() == true)
        {
            {
                this.persuadeAp += amount;

                if (this.persuadeAp >= 10 && level == 5)
                {
                    this.persuadeAp = 10;
                }
                else if (this.persuadeAp >= 15 && level == 10)
                {
                    this.persuadeAp = 15;
                }
                if (this.persuadeAp >= 20 && level == 20)
                {
                    this.persuadeAp = 20;
                }
                else if (this.persuadeAp >= 25 && level == 30)
                {
                    this.persuadeAp = 25;
                }
            }
        }
        if(CombatActions.Instance.ReturnIncreasingMockAP() == true)
        {
            {
                this.mockAp += amount;

                if (this.mockAp >= 5 && level == 5)
                {
                    this.mockAp = 5;
                }
                else if (this.mockAp >= 10 && level == 10)
                {
                    this.mockAp = 10;
                }
                if (this.mockAp >= 15 && level == 20)
                {
                    this.mockAp = 15;
                }
                else if (this.mockAp >= 20 && level == 30)
                {
                    this.mockAp = 20;
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
