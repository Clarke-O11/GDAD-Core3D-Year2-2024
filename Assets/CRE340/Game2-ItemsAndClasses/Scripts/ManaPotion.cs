using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : Item
{
    public int manaRestoreAmount;
    public int minRestoreAmount = 20;
    public int maxRestoreAmount = 50;

    public ManaPotion() 
    {
        itemName = "ManaPotion";
        itemDescription = "A potion that restores mana.";
    }

    // Start is called before the first frame update
    void Start()
    {
        manaRestoreAmount = Random.Range(minRestoreAmount, maxRestoreAmount);
        Debug.Log($"ManaPotion: Random restore amount set to {manaRestoreAmount}.");
    }

    public override void DisplayInfo()
    {
        Debug.Log($"{itemName}: Restores {manaRestoreAmount} mana points.");
    }
}
