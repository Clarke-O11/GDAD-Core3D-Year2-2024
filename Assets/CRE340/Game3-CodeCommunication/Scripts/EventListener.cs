using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    public TextMeshProUGUI logText;
    public int lineCount = 10;

    private void OnEnable()
    {
        HealthEventManager.OnObjectDamaged += HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed += HandleObjectDestroyed;
    }

    private void OnDisable()
    {
        HealthEventManager.OnObjectDamaged -= HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed -= HandleObjectDestroyed;
    }

    private void HandleObjectDamaged(string name, int remainingHealth) 
    {
        string message = $"An object was damaged! Remaining Health: {remainingHealth}";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }

    private void HandleObjectDestroyed(string name, int remainingHealth)
    {
        string message = $"An object was destroyed!";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }

    private void UpdateLog(string message, int maxLines) 
    {
        if (logText != null)
        {
            var lines = logText.text.Split('\n').ToList();

            lines.Add(message);

            if (lineCount > maxLines)
            {
                lines.RemoveAt(0);
            }
            logText.text = string.Join("\n", lines);
        }
    }







}
