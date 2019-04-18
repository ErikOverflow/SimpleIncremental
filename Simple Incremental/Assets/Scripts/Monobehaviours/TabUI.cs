using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabUI : MonoBehaviour
{

    [SerializeField]
    PanelUI mainPanel = null;
    [SerializeField]
    GameObject activeTab = null;

    BackpackUI backpackUI = null;

    private void Awake()
    {
        backpackUI = BackpackUI.instance;
    }

    public void Clicked()
    {
        backpackUI.OpenPanel(mainPanel);
    }

    public void ActivateTab()
    {
        activeTab.SetActive(true);
    }

    public void DeactivateTab()
    {
        activeTab.SetActive(false);
    }
}
