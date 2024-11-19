using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProperties
{
    public string name;
    public int experience;
    public int coins;
    public List<string> inventory;

    public SaveLoadManager saveLoadManager;

    public PlayerProperties(string name, int experience, int coins,List<string> inventory) 
    { 
        this.name = name;
        this.experience = experience;
        this.coins = coins;
        this.inventory = inventory;
    }

    public PlayerProperties() 
    {
        name = "Player";
        experience = 0;
        coins = 0;
        inventory = new List<string>();
    }

    public string PlayerName 
    { 
        get { return name; }
        private set 
        {  
            name = value;
            UIEventHandler.PlayerNameChanged(name);
            saveLoadManager.SetPlayerName(name);
        }
    }

    public int Experience
    {
        get { return experience; }
            private set 
        { 
            experience = value;
            UIEventHandler.ExperienceChanged(experience);
            saveLoadManager.GainExperience(experience);
        }
    }

    public int Coins
    {
        get { return coins; }
        private set
        {
            coins = value;
            UIEventHandler.CoinsChanged(coins);
            saveLoadManager.AddCoins(coins);
        }
    }

    private void OnApplicationQuit() 
    { 
        if (saveLoadManager.autoSave) 
        { 
            saveLoadManager.SaveData();
        }
    }

    private void OnDisable() 
    {
        if (saveLoadManager.autoSave)
        {
            saveLoadManager.SaveData();
        }
    }
}
