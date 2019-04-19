using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    Animator anim = null;

    public string title = "Panel";
    [SerializeField]
    UITab tab = null;
    [SerializeField]
    UISubPanel[] subPanels = null;

    public virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenPanel(string dir)
    {
        tab.ActivateTab();
        anim.SetTrigger("OpenPanel" + dir);
        OpenSubPanels();
    }

    public void ClosePanel(string dir)
    {
        tab.DeactivateTab();
        anim.SetTrigger("ClosePanel" + dir);
        CloseSubPanels();
    }

    public void OpenSubPanels()
    {
        foreach(UISubPanel subPanel in subPanels)
        {
            subPanel.OpenPanel();
        }
    }

    public void CloseSubPanels()
    {
        foreach (UISubPanel subPanel in subPanels)
        {
            subPanel.ClosePanel();
        }
    }
    public virtual void UpdateUI()
    {
        foreach(UISubPanel subPanel in subPanels)
        {
            subPanel.UpdateUI();
        }
    }
}
