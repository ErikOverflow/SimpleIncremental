using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    CharacterHealth ch = null;

    [SerializeField]
    GameEvent playerDied = null;

    private void Awake()
    {
        ch = GetComponent<CharacterHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ch.OnDeath += playerDied.Raise;
    }    
}
