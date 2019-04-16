using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUI : MonoBehaviour
{
    public static BackpackUI instance;

    [Header("UI Objects")]
    [SerializeField]
    Image backpackImage = null;
    [SerializeField]
    Sprite openBackpackSprite = null;

    [Header("Animator")]
    public Animator anim = null;

    [Header("PlayerObject")]
    public GameObject player = null;

    public PanelUI activePanel = null;
    bool opened = false;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        activePanel.OpenPanel();
    }

    public void ToggleInventory()
    {
        opened = !opened;
        if (opened)
        {
            backpackImage.overrideSprite = openBackpackSprite;
            anim.SetTrigger("OpenBackpack");
            UpdateUI();
        }
        else
        {
            backpackImage.overrideSprite = null;
            anim.SetTrigger("CloseBackpack");
        }   
    }
}
