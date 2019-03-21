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
        Vector3 randomRange = Vector3.zero;

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

        //Spawn a new object from the object pooler
        GameObject newObject = ObjectPooler.instance.GetPooledObject(objectPrefab);
        if (newObject != null)
        {
            newObject.transform.SetParent(transform);
            newObject.transform.localPosition = randomRange;
            newObject.transform.rotation = Quaternion.identity;
            newObject.SetActive(true);
            spawnCount++;
        }
    }
}
