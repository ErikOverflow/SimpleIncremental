using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HudExpUI : MonoBehaviour
{
    public GameObject player;
    Slider healthBar;
    //CharacterHealth characterHealth;

    private void Awake()
    {
        //characterHealth = player.GetComponent<CharacterHealth>();
        //healthBar = GetComponent<Slider>();
        //healthBar.maxValue = characterHealth.maxHealth;
    }

    void Start()
    {
        //characterHealth.HealthChanged += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        /*
        if (characterHealth.health <= 0)
        {
            transform.gameObject.SetActive(false);
        }
        healthBar.value = characterHealth.health;
        */
    }
}
