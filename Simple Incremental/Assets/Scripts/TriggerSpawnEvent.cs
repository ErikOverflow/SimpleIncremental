using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnEvent : MonoBehaviour
{
    [SerializeField]
    bool triggered = false;

    [SerializeField]
    public int triggerID; //ID should match value of the spawn triggerID

    [SerializeField]
    GameEvent triggerEvent = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        // When an object colides with the colider trigger the 
        if (!triggered && other.tag == "Player")
        {
            triggered = true;
            triggerEvent.Raise(gameObject);
        }
    }
}
