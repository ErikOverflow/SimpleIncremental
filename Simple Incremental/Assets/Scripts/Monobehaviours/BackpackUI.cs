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
    [SerializeField]
    PanelUI activePanel = null;

    [SerializeField]
    List<PanelUI> mainUIPanels = null;

    [Header("Animator")]
    public Animator anim = null;

    [Header("PlayerObject")]
    public GameObject player = null;

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

    public void OpenPanel(PanelUI newActivePanel)
    {
        if (newActivePanel == activePanel)
            return;
        if (mainUIPanels.IndexOf(activePanel) < mainUIPanels.IndexOf(newActivePanel))
        {
            activePanel.ClosePanel("Up");
            newActivePanel.OpenPanel("Up");
        }
        else
        {
            activePanel.ClosePanel("Down");
            newActivePanel.OpenPanel("Down");
        }
        activePanel = newActivePanel;
    }

    private void UpdateAllUI()
    {
        foreach(PanelUI panel in mainUIPanels)
        {
            panel.UpdateUI();
        }
    }

    public void ToggleInventory()
    {
        opened = !opened;
        if (opened)
        {
            UpdateAllUI();
            backpackImage.overrideSprite = openBackpackSprite;
            anim.SetTrigger("OpenBackpack");
        }
        else
        {
            backpackImage.overrideSprite = null;
            anim.SetTrigger("CloseBackpack");
        }   
    }
}
