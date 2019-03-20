using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Spawner for objects thats works using specified object pooler
 * This will spawn objects from the pooler at the specified location*/
public class SpawnPointPool : SpawnPoint
{
    public ObjectPooler objectPooler;

    public override void SpawnObject()
    {
        //Spawn a new object from the object pooler
        GameObject newObject = objectPooler.GetPooledObject(objectPrefab);
        if (newObject != null)
        {
            newObject.transform.position = transform.position;
            newObject.transform.rotation = transform.rotation;
            newObject.SetActive(true);
            //Set this item as the parent to the object
            newObject.transform.SetParent(transform);
            //Notify the game a new object has spawned
            spawnEvent.Raise(newObject);
            //Track number of objects spawned
            spawnedObjCount++;
        }
    }
}

