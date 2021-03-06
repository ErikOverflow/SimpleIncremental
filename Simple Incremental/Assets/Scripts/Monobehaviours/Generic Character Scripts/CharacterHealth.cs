﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public event Action HealthChanged;
    public event Action OnDeath;
    public event Action<CharacterHealth> UnTarget;

    public void ResetHealth()
    {
        health = maxHealth;
        HealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            Mathf.Clamp(health, 0, maxHealth);
            if (health == 0)
            {
                OnDeath?.Invoke();
                UnTarget?.Invoke(this);
            }
            HealthChanged?.Invoke();
        }
    }

    public void Heal(int healthAmount)
    {
        health += healthAmount;
        Mathf.Clamp(health, 0, maxHealth);
        HealthChanged?.Invoke();
    }
}
