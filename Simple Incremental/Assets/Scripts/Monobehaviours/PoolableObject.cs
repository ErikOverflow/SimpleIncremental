using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab = null;

    private void OnDisable()
    {
        if(prefab != null)
            ObjectPooler.instance.ReleasePooledObject(this);
    }
}