using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject healthPotionPrefab;
    public GameObject manaPotionPrefab;

    public int numberOfItemsEachSide = 3;
    public float spacing = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        SpawnHealthPotions();
        SpawnManaPotions();
    }

    void SpawnHealthPotions() 
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            Vector3 position = new Vector3(i * spacing, -0.5f, 0);
            GameObject newHealthPotion = Instantiate(healthPotionPrefab, position, Quaternion.identity);
            HealthPotion healthPotionItem = newHealthPotion.GetComponent<HealthPotion>();
            if (healthPotionItem != null)
            {
                healthPotionItem.DisplayInfo();
            }
            else 
            {
                Debug.LogWarning("The instantiated health potion does not have the HealthPotion component!");
            }
        }
    }

    void SpawnManaPotions() 
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            Vector3 position = new Vector3(i * spacing, -0.5f, -4.0f);
            GameObject newManaPotion = Instantiate(manaPotionPrefab, position, Quaternion.identity);
            ManaPotion manaPotionItem = newManaPotion.GetComponent<ManaPotion>();
            if (manaPotionItem != null)
            {
                manaPotionItem.DisplayInfo();
            }
            else
            {
                Debug.LogWarning("The instantiated health potion does not have the ManaPotion component!");
            }
        }
    }
}
