using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
[CustomEditor(typeof(EnemyStatsSystem))]
public class EnemyStatsSystemEditor : Editor
{
    EnemyStatsSystem myStatSystem;
    public override void OnInspectorGUI() //This is all just a fancy way to make a button to trigger "Recalculate"
    {
        DrawDefaultInspector();
        myStatSystem = (EnemyStatsSystem)target;
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
        EnemyHook enemyHook = myStatSystem.GetComponent<EnemyHook>();
        enemyHook.Awake();
        StatAugment[] statAugments = myStatSystem.GetComponentsInChildren<StatAugment>();
        foreach (StatAugment augment in statAugments)
        {
            augment.Awake();
        }
        myStatSystem.ApplyAugments();
    }
}
#endif