using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory
{
    public static EnemyBase CreateEnemy(EnemyData enemyData, Vector3 position) 
    {
        if (enemyData.enemyPrefab == null) 
        {
            Debug.LogError($"Enemy prefab not asssigned in {enemyData.name!}");
            return null;
        }

        GameObject enemyInstance = GameObject.Instantiate(enemyData.enemyPrefab, position, Quaternion.identity);

        EnemyBase enemy = enemyInstance.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.GetComponent<Enemy>().enemyData = enemyData;
        }
        else 
        {
            Debug.LogError("The prefab does not contain an EnemyBase component!");
        }

        Debug.Log($"Created {enemyData} at {position}");
        return enemy;
    }
}
