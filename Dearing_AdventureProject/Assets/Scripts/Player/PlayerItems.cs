using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems
{
    private string itemName;
    private int itemQuantity;
    private int aPBoost;
    private int healing;


    private PlayerItems(string itemName, int healing,int aPBoost, int itemQuantity)
    {
        this.itemName = itemName;
        this.healing = healing;
        this.itemQuantity = itemQuantity;
        this.aPBoost = aPBoost;
        
    }

    public static PlayerItems Create(string itemName, int healing,int aPBoost, int itemQuanity)
    {
        return new PlayerItems(itemName,  healing, aPBoost, itemQuanity);
    }

    public void UseItem(int depleted)
    {
        itemQuantity -= depleted;

        if (itemQuantity <= 0)
        {
            itemQuantity = 0;
        }
    }
    

    public int GetHealing()
    {
        return this.healing;
    }
    public string GetItemName()
    {
        return this.itemName;
    }
    public int GetItemQuantity() 
    { 
        return this.itemQuantity;
    }
    public int GetAPBoost()
    {
        return this.aPBoost;
    }
    
}

