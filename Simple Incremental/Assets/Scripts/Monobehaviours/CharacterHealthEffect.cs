using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterHealth))]
[RequireComponent(typeof(ParticleSystem))]
public class CharacterHealthEffect : MonoBehaviour
{
    CharacterHealth characterHealth;
    ParticleSystem system;

    void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        system = GetComponent<ParticleSystem>();
    }
    void Start()
    {
        characterHealth.HealthChanged += playHitEffect;
    }

    private void playHitEffect()
    {
        //When players health changes play damage partice effect
        system.Play();
    }
}
