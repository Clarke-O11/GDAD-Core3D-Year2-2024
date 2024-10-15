using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IDamagable
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

        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, health);
        if (health <= 0) 
        {
            Destroy(gameObject);
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, health);
        }
    }

    public void ShowHitEffect() 
    { 
        mat.color = Color.green;
        Invoke("ResetMaterial", 0.1f);
    }
    private void ResetMaterial() 
    { 
        mat.color = originalColour;
    }

}
