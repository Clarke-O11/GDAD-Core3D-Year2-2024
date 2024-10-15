using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyData enemyData;
    public int health = 10;
    private Material mat;
    private Color originalColour;

    private void Awake()
    {
        gameObject.name = enemyData.enemyName;
        GetComponent<Renderer>().material.color = enemyData.enemyColor;
        Debug.Log($"Enemy {enemyData.enemyName} spawned with {enemyData.health} health and {enemyData.speed} speed.");
    }
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColour = mat.color;
    }

    public void TakeDamage(int damage) 
    { 
        health -= damage;

        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, health);
        
        ShowHitEffect();

        if (health <= 0) 
        {
            Die();
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, health);
        }
    }

    public void ShowHitEffect() 
    { 
        mat.color = Color.red;
        Invoke("ResetMaterial", 0.1f);
    }

    private void ResetMaterial() 
    { 
        mat.color = originalColour;
    }

    private void Die() 
    { 
        Destroy(gameObject);
    }
}
