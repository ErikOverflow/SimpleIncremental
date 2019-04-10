using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    [Header("Text/Slider elements to be modified")]
    [SerializeField]
    TextMeshProUGUI levelTMPro = null;
    [SerializeField]
    Slider healthSlider = null;
    [SerializeField]
    Slider experienceSlider = null;

    [Header("Player GameObject")]
    [SerializeField]
    GameObject player = null;
    CharacterHealth characterHealth = null;
    PlayerLevel playerLevel = null;
    // Start is called before the first frame update
    void Awake()
    {
        characterHealth = player.GetComponent<CharacterHealth>();
        playerLevel = player.GetComponent<PlayerLevel>();
    }

    private void Start()
    {
        characterHealth.HealthChanged += UpdateUI;
        playerLevel.OnLevelUp += UpdateUI;
        playerLevel.OnExperienceGained += UpdateUI;
    }

    private void OnDestroy()
    {
        characterHealth.HealthChanged -= UpdateUI;
        playerLevel.OnLevelUp -= UpdateUI;
        playerLevel.OnExperienceGained -= UpdateUI;
    }

    private void UpdateUI()
    {
        healthSlider.maxValue = characterHealth.maxHealth;
        healthSlider.value = characterHealth.health;
        experienceSlider.maxValue = playerLevel.nextLevelExp;
        experienceSlider.value = playerLevel.experience;
        levelTMPro.text = playerLevel.level.ToString();
    }
}
