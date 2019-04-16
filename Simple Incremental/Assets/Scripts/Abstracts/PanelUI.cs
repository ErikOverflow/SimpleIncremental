using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelUI : MonoBehaviour
{
    Animator anim = null;
    BackpackUI backpackUI = null;

    public virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Start()
    {
        backpackUI = BackpackUI.instance;
    }

    public void OpenPanel()
    {
        UpdateUI();
        if(backpackUI.activePanel != this)
        {
            backpackUI.activePanel.ClosePanel();
            backpackUI.activePanel = this;
            anim.SetTrigger("OpenPanel");
        }
    }

    public void ClosePanel()
    {
        anim.SetTrigger("ClosePanel");
    }
    public abstract void UpdateUI();
}
