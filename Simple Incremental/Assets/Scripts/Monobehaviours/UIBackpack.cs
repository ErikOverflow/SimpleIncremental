using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBackpack : MonoBehaviour
{
    public static UIBackpack instance;

    [Header("UI Objects")]
    [SerializeField]
    Image backpackImage = null;
    [SerializeField]
    Sprite openBackpackSprite = null;
    [SerializeField]
    List<UIPanel> mainUIPanels = null;
    [SerializeField]
    UIPanel startingPanel = null;
    [SerializeField]
    TextMeshProUGUI mainPanelTitleText = null;

    [Header("Animator")]
    public Animator anim = null;

    [Header("PlayerObject")]
    public GameObject player = null;

    bool opened = false;
    UIPanel activePanel = null;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            if (startingPanel == null)
                startingPanel = mainUIPanels.FirstOrDefault();
        }
    }

    public void OpenPanel(UIPanel newActivePanel)
    {
        if (newActivePanel == activePanel)
            return;
        if (mainUIPanels.IndexOf(activePanel) < mainUIPanels.IndexOf(newActivePanel))
        {
            activePanel?.ClosePanel("Up");
            newActivePanel.OpenPanel("Up");
        }
        else
        {
            activePanel?.ClosePanel("Down");
            newActivePanel.OpenPanel("Down");
        }
        mainPanelTitleText.text = newActivePanel.title;
        activePanel = newActivePanel;
    }

    public void UpdateAllUI()
    {
        foreach(UIPanel panel in mainUIPanels)
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
            OpenPanel(startingPanel);
        }
        else
        {
            backpackImage.overrideSprite = null;
            anim.SetTrigger("CloseBackpack");
        }   
    }
}
