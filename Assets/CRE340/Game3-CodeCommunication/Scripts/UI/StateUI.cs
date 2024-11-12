using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    private Enemy enemy;

    
    void Awake()
    {
        enemy = GetComponent<Enemy>();

        if (textMesh == null) 
        {
            textMesh = GetComponent<TextMeshPro>();
        }

        if (textMesh == null) 
        {
            Debug.LogError("TextMeshPro component not found on StateUI!");
        }
    }


    void Update()
    {
        UpdateStateText();
    }

    public void UpdateStateText() 
    {
        if (enemy != null && textMesh == null)
        { 
            textMesh.text = enemy.GetCurrentStateName();
        }
    }
}
