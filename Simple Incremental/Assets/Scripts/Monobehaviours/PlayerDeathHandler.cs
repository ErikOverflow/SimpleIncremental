﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    CharacterHealth ch = null;
    Animator anim;
    [SerializeField]
    int deathHash = Animator.StringToHash("Death");

    private void Awake()
    {
        ch = GetComponent<CharacterHealth>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ch.OnDeath += PlayerDied;
    }    
    
    private void PlayerDied()
    {
        anim.SetTrigger(deathHash);
    }
}