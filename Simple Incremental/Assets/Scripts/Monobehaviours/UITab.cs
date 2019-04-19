using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITab : MonoBehaviour
{

    [SerializeField]
    UIPanel mainPanel = null;
    [SerializeField]
    GameObject activeTab = null;

    public void Clicked()
    {
        UIBackpack.instance.OpenPanel(mainPanel);
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
