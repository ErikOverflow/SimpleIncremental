using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterHealth))]
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
        if (system != null)
        {
            var main = system.main;
            main.startLifetime = 0.5f;
            main.startSpeed = 0.5f;
            var em = system.emission;
            em.rateOverTime = 10;
            system.Play();
        }
    }
    public void playDeathEffect(GameObject go)
    {
        // When Character dies play death effect
        if (system != null)
        {
            var main = system.main;
            main.startLifetime = 3f;
            main.startSpeed = 1f;
            var em = system.emission;
            em.rateOverTime = 1000;
            system.Play();
        }
    }
}
