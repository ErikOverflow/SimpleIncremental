using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Used to spawn objects at the borders of the screen
 * This is an extension of the SpawnPoint class and allows
 * for objects to spawn at the edge of the screen */
public class SpawnPointRandomBorders : SpawnPoint
{
    public float spawnHeight; //Hight of location from object to spawn objects
    public float spawnWidth; //Width of location from object to spawn objects
    public ObjectPooler objectPooler;

    public override void SpawnObject()
    {

        //Spawn a new object at a random location 
        Vector3 randomRange;
        Vector3 origin = transform.position;

        //Force the spawn to happen at the edge of the screen except the bottom
        switch (Random.Range(0, 4))
        {
            case 0:
                randomRange = new Vector3(spawnWidth, Random.Range(-spawnHeight, spawnHeight), 0);
                break;
            case 1:
                randomRange = new Vector3(-spawnWidth, Random.Range(-spawnHeight, spawnHeight), 0);
                break;
            default:
                randomRange = new Vector3(Random.Range(-spawnWidth, spawnWidth), spawnHeight, 0);
                break;
        }

        //Offset the spawn by the origin location of the object Container
        Vector3 randomCoordinate = origin + randomRange;


        //Spawn a new object from the object pooler
        GameObject newObject = objectPooler.GetPooledObject(objectPrefab);
        if (newObject != null)
        {
            newObject.transform.position = randomCoordinate;
            newObject.transform.rotation = Quaternion.identity;
            newObject.SetActive(true);
            //Set this item as the parent to the object
            newObject.transform.SetParent(transform);
            //Notify the game a new object has spawned
            spawnEvent.Raise(newObject);
            //Track number of objects spawned
            spawnedObjCount++;
        }
    }
    public override void RemoveObject(GameObject go)
    {
        //if (go != null && GameObject.ReferenceEquals(go.transform.parent.gameObject, gameObject))
        if (go != null && go.transform.parent.gameObject.GetInstanceID() == gameObject.GetInstanceID())
        {
            //Remove the object
            go.SetActive(false);
            objectPooler.ReleasePooledObject(go);
        }
    }
}
