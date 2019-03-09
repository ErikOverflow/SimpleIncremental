using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public event HealthChangeHandler HealthChanged;
    public delegate void HealthChangeHandler();

    private void Start()
    {
        ReCalculateHealth();
    }

    public void ReCalculateHealth()
    {
        health = maxHealth;

        //To do: When an enemy is newly spawned, calculate health
    }

    public void TakeDamage(int damage)
    {
        if(health > 0)
        {
            health -= damage;
            HealthChanged?.Invoke();
            if (health <= 0)
            {
                //Death Event;
                health = 0;
            }
        }
    }

    public void Heal(int healthAmount)
    {
        health += healthAmount;
        HealthChanged?.Invoke();
        if (health >= maxHealth)
        {
            //Heal event
            health = maxHealth;
        }
    }
}
