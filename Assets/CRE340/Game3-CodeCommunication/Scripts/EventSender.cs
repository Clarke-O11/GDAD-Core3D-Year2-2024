using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSender : MonoBehaviour
{
    public delegate void FireEventHandler(float scale, float speed);

    public static event FireEventHandler OnFire;

    [Header("Parameters to pass with the event")]
    public float scale = 2.0f;
    public float speed = 10.0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (OnFire != null) 
            { 
                OnFire(scale, speed);
            }
        }
    }
}
