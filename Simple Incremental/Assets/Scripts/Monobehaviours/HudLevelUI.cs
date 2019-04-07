using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HudLevelUI : MonoBehaviour
{
    public GameObject player;
    Text levelText;
    CharacterLevel characterLevel;

    private void Awake()
    {
        characterLevel = player.GetComponent<CharacterLevel>();
        levelText = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        levelText.text = characterLevel.level.ToString();
    }

}
