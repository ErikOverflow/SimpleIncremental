using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    public event TriggerHandler OnTriggered;
    public delegate void TriggerHandler(GameObject go);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggered?.Invoke(collision.gameObject); //Alert any subscribers that something stepped on the trigger
    }
}
