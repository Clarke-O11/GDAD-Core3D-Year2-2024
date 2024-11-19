using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static UnityEditor.Progress;

public class SaveLoadManager : MonoBehaviour
{
    [Header("Save and Load Options")]
    [Space(10)]
    public bool autoLoad;
    public bool autoSave;

    [Header("Player Properties to Save and Load")]
    [Space(10)]
    public PlayerProperties playerProperties;

    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/playerData.json";

        if (playerProperties == null) 
        { 
            playerProperties = new PlayerProperties();
        }

        if (autoLoad) 
        {
            LoadData();
        }
    }

    public void LoadData() 
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerProperties = JsonUtility.FromJson<PlayerProperties>(json);
            Debug.Log("Data loaded from " + filePath);
        }
        else 
        {
            Debug.LogWarning("Save file not found at " + filePath);
        }
    }

    public void SaveData() 
    { 
        string json = JsonUtility.ToJson(playerProperties, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved to " + filePath);
    }

    public void ClearData() 
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Save data cleared from " + filePath);
        }
        else
        {
            Debug.LogWarning("No save file to delete at " + filePath);
        }

        playerProperties = new PlayerProperties();
    }

    public void AddToIventory(string item) 
    { 
        playerProperties.inventory.Add(item);
        Debug.Log(item + "added to inventory");
    }

    public void GainExperience(int amount) 
    {
        playerProperties.experience += amount;
        Debug.Log("Gained" + amount + " experience. Total: " + playerProperties.experience);
    }

    public void AddCoins(int amount) 
    {
        playerProperties.coins += amount;
        Debug.Log("Gained" + amount + " coins. Total: " + playerProperties.coins);
    }


    public void SetPlayerName(string name) 
    {  
        playerProperties.name = name;
        Debug.Log("Player name set to " + name);
    } 

}
