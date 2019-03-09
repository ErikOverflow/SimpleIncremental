using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public event HealthChangeHandler HealthChanged;
    public delegate void HealthChangeHandler();

    [SerializeField]
    GameEvent deathEvent = null;

    [SerializeField]
    GameEvent healEvent = null;

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
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                deathEvent.Raise(gameObject);
                gameObject.SetActive(false);
            }
            HealthChanged?.Invoke();
        }
    }

    public void Heal(int healthAmount)
    {
        health += healthAmount;
        if (health >= maxHealth)
        {
            health = maxHealth;
            healEvent.Raise();
        }
        HealthChanged?.Invoke();
    }
}
