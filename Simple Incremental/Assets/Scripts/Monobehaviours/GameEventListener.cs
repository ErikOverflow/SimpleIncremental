using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent[] Events;
    public UnityEvent Response;

    private void OnEnable()
    {
        foreach(GameEvent e in Events)
        {
            e.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        foreach(GameEvent e in Events)
        {
            e.UnregisterListener(this);
        }
    }

    public void OnEventsRaised()
    {
        Response.Invoke();
    }
}