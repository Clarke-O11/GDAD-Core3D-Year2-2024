using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HealthEventManager
{
    public delegate void HealthEvent(int currentHealth);

    public static HealthEvent OnObjectDamaged;

    public static HealthEvent OnObjectDestroyed;

}
