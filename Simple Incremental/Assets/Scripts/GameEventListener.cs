using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent[] Events;
    public UnityEvent Response;
    public GameEventWithObject ResponseWithObject;

    private void OnEnable()
    {
        foreach(GameEvent e in Events)
        {
            e.RegisterListener(this);
        }
    }

    public void OnEventsRaised()
    {
        Response.Invoke();
    }

    public void OnEventsRaised(GameObject go)
    {
        ResponseWithObject.Invoke(go);
    }
}

[Serializable]
public class GameEventWithObject : UnityEvent<GameObject> { }