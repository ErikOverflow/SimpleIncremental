using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    private int health;
    public int maxHealth = 10;

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
        if(health >= maxHealth)
        {
            //Heal event
            health = maxHealth;
        }
    }
}
