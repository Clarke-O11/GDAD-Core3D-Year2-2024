using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCrate : MonoBehaviour, IDamagable
{
    public int health = 10;
    public GameObject explosionEffectPrefab;
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
       
        ShowHitEffect();

        if (health <= 0) 
        {
            Explode();
            Destroy(gameObject); 
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

    private void Explode() 
    {
        if (explosionEffectPrefab != null) 
        { 
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
    }

}
