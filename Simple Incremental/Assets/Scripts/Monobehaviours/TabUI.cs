using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabUI : MonoBehaviour
{

    [SerializeField]
    PanelUI panel = null;
    [SerializeField]
    GameObject activeTab = null;

    BackpackUI backpackUI = null;

    private void Awake()
    {
        backpackUI = BackpackUI.instance;
    }

    public void Clicked()
    {
        backpackUI.OpenPanel(panel);
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
