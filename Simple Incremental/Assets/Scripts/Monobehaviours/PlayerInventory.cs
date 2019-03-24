using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    //[HideInInspector] //Polymorphism doesn't play nice with the inspector, so this isn't the place to maintain item inventory from the editor.
    [ReadOnly]
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

public class ReadOnlyAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty prop, GUIContent label)
    {
        bool wasEnabled = GUI.enabled;
        GUI.enabled = false;
        EditorGUI.PropertyField(rect, prop);
        GUI.enabled = wasEnabled;
    }
}