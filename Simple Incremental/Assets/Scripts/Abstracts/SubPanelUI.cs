using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubPanelUI : MonoBehaviour
{
    Animator anim = null;

    public virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenPanel()
    {
        anim.SetTrigger("OpenSubPanel");
    }

    public void ClosePanel()
    {
        anim.SetTrigger("CloseSubPanel");
    }
    public abstract void UpdateUI();
}
