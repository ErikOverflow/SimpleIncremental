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
        levelText.text = (string)characterLevel.level.ToString();
    }

}
