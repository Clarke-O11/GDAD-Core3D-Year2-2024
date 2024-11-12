using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public int damage;
    public float speed;
    public Color enemyColor;
    public GameObject enemyPrefab;
    public float chaseRange;
}
