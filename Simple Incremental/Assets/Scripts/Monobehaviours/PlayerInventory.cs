using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    [HideInInspector] //Polymorphism doesn't play nice with the inspector, so this isn't the place to maintain item inventory from the editor.
    public List<ItemInstance> items = new List<ItemInstance>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
