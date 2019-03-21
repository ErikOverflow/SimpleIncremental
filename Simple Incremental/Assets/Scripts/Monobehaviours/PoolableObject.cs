using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;
    public string prefabName = null;

    private void OnDisable()
    {
        if(prefabName == null && prefab != null)
        {
            prefabName = prefab.name;
        }
        ObjectPooler.instance.ReleasePooledObject(this);
    }
}