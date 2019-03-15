using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponStatsSystem))]
public class WeaponStatsSystemEditor : Editor
{
    WeaponStatsSystem myStatSystem;
    public override void OnInspectorGUI() //This is all just a fancy way to make a button to trigger "Recalculate"
    {
        DrawDefaultInspector();
        myStatSystem = (WeaponStatsSystem)target;
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Recalculate Stats", GUILayout.MaxWidth(200), GUILayout.Height(50)))
        {
            Recalculate();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

    }

    //This is for initializing values in the editor only. ApplyAugments will be triggered during build by a GameEventListener listening for any type of stat changes
    public void Recalculate()
    {
        myStatSystem.Awake();
        WeaponHook weaponHook = myStatSystem.GetComponent<WeaponHook>();
        weaponHook.Awake();
        ProjectileWeapon projectileWeapon = myStatSystem.GetComponent<ProjectileWeapon>();
        projectileWeapon.Awake();
        StatAugment[] statAugments = myStatSystem.GetComponentsInChildren<StatAugment>();
        foreach (StatAugment augment in statAugments)
        {
            augment.Awake();
        }
        myStatSystem.ApplyAugments();
    }

}