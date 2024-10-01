using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemDescription;

    public Item() 
    {
        itemName = "Generic Item";
        itemDescription = "A generic item";
    }

    public Item(string newItemName, string newitemDescription) 
    {
        itemName = newItemName;
        itemDescription = newitemDescription;
    }

    public virtual void DisplayInfo() 
    {
        Debug.Log($"{itemName} : {itemDescription}");
    }

}
