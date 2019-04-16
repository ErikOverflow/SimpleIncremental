using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelUI : MonoBehaviour
{
    public abstract void ClosePanel();
    public abstract void OpenPanel();
    public abstract void UpdateUI();
}
