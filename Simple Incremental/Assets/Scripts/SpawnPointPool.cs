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
        GameObject newObject = objectPooler.GetPooledObject();
        if (newObject != null)
        {
            newObject.transform.position = transform.position;
            newObject.transform.rotation = transform.rotation;
            newObject.SetActive(true);
            //Notify the game a new object has spawned
            spawnEvent.Raise(newObject);
            //Track number of objects spawned
            spawnedObjCount++;
        }
    }
    public override void RemoveObject(GameObject go)
    {
        if (go != null && GameObject.ReferenceEquals(go.transform.parent.gameObject, gameObject))
        {
            //Remove the object
            go.SetActive(false);
        }
    }


}

