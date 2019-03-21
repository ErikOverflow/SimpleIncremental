using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* This class is used for pooling objects and reusing objects for performance
 * This works best when lots of the same object are spawned multiple times
 * such as projectiles from a gun */
public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
    public Dictionary<string, Queue<GameObject>> dict = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            dict = new Dictionary<string, Queue<GameObject>>();
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject GetPooledObject(GameObject go)
    {
        if (!dict.ContainsKey(go.name))
        {
            dict.Add(go.name, new Queue<GameObject>());
        }

        if (dict[go.name].Count > 0)
        {
            return dict[go.name].Dequeue();
        }
        else
        {
            GameObject newGo = Instantiate(go);
            PoolableObject po = newGo.GetComponent<PoolableObject>();
            if( po == null)
            {
                po = newGo.AddComponent<PoolableObject>();
            }
            po.prefabName = go.name;
            return newGo;
        }

    }

    public void ReleasePooledObject(PoolableObject po)
    {
        if (!dict.ContainsKey(po.prefabName))
        {
            dict.Add(po.prefabName, new Queue<GameObject>());
        }
        dict[po.prefabName].Enqueue(po.gameObject);

        Debug.Log(dict.Count);
    }
}