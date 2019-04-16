using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabUI : MonoBehaviour
{

    [SerializeField]
    PanelUI panel = null;

    public void Clicked()
    {
        panel.UpdateUI();
        panel.OpenPanel();
    }
}
