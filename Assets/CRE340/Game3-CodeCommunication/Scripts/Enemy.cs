using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{

    public int health = 10;
    private Material mat;
    private Color originalColour;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColour = mat.color;
    }

    public void TakeDamage(int damage) 
    { 
        health -= damage;

        HealthEventManager.OnObjectDamaged?.Invoke(health);
        ShowHitEffect();

        if (health <= 0) 
        {
            Die();
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
