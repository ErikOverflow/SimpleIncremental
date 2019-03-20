using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* This class is used for pooling objects and reusing objects for performance
 * This works best when lots of the same object are spawned multiple times
 * such as projectiles from a gun */
public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
    public List<GameObject> objectsToPool; //List of game objects that will be initially poooled
    public int initialPoolSize; //The number of initial objects that will be created for each pooled object
    public int increaseAmount; //Number of objects to create when min pool size is reached
    public int minPoolSize; //Minimum size before more objects are added
    private static Dictionary<string, Queue<GameObject>> dict = new Dictionary<string, Queue<GameObject>>();

void Awake()
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

    void Start()
    {
        foreach (GameObject obj in objectsToPool)
        {
            AddPoolObjects(obj, initialPoolSize);
        }
    }

    public GameObject GetPooledObject(GameObject go)
    {
        string name = go.name;
        if (!dict.ContainsKey(name))
        {
            dict.Add(name, new Queue<GameObject>());

        }

        if (dict[go.name].Count <= minPoolSize)
        {
            AddPoolObjects(go, increaseAmount);
        }
        return dict[go.name].Dequeue();
    }       

    public void ReleasePooledObject(GameObject go)
    {
        string name = go.name;
        if (!dict.ContainsKey(name))
        {
            dict.Add(name, new Queue<GameObject>());

        }
        dict[go.name].Enqueue(go);
    }

    private void AddPoolObjects (GameObject go, int amountToAdd)
    {
        string name = go.name;
        if (!dict.ContainsKey(name))
        {
            dict.Add(name, new Queue<GameObject>());

        }
        for (int i = 0; i < amountToAdd; i++)
        {
            GameObject obj = (GameObject)Instantiate(go);
            obj.name = name;
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            dict[name].Enqueue(obj);
        }
    }
}
