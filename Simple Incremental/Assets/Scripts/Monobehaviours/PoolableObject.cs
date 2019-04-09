using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;
    [NonSerialized]
    public string prefabName = null;

    private void Awake()
    {
        if (prefabName == null && prefab != null)
        {
            prefabName = prefab.name;
        }
    }

    private void OnDisable()
    {
        if(prefab != null)
            ObjectPooler.instance.ReleasePooledObject(this);
    }
}