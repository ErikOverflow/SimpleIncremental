using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelUI : MonoBehaviour
{
    Animator anim = null;
    BackpackUI backpackUI = null;

    [SerializeField]
    TabUI tab = null;

    public virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Start()
    {
        backpackUI = BackpackUI.instance;
    }

    public void OpenPanel(string dir)
    {
        tab.ActivateTab();
        anim.SetTrigger("OpenPanel" + dir);
    }

    public void ClosePanel(string dir)
    {
        tab.DeactivateTab();
        anim.SetTrigger("ClosePanel" + dir);
    }
    public abstract void UpdateUI();
}
