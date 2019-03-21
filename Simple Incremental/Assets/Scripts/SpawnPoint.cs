using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Spawn point is used in conjunction with the TriggerPoint to spawn new objects
 * When a trigger event is seen it will invoke this method to spawn objects
 * via the configured manner.*/
public class SpawnPoint : MonoBehaviour
{
    public GameObject objectPrefab; //Object that will be spawned
    public int spawnCount; //Number of Objects to Spawn, 0 for infinite
    public int spawnDelay; //Time in seconds to wait before spawning next object
    public int triggerID; //ID should match value of the triggers triggerID

    [SerializeField]
    protected GameEvent spawnEvent = null;

    [SerializeField]
    protected int spawnedObjCount = 0; //Number of objects allready spawned

    protected Coroutine spawnCorotine = null; // Reference to the spawn control corotine

    public void StartSpawning(GameObject go)
    {
        TriggerSpawnEvent trigger = go.GetComponent<TriggerSpawnEvent>();
        // Start the Corotine if it's not allready running, and hasn't ran before
        if (spawnCorotine == null && trigger.triggerID == triggerID)
        {
            spawnCorotine = StartCoroutine(SpawnEnemiesControl());
        }   
    }

    public void StopSpawning()
    {
        // Stop the spawn corotine if its running
        if (spawnCorotine != null)
        {
            StopCoroutine(spawnCorotine);
            spawnCorotine = null;
        }
    }

    public virtual void SpawnObject()
    {
        //Spawn the new object into the world
        GameObject newObject = Instantiate(objectPrefab, transform);

        //Set this item as the parent to the object
        newObject.transform.SetParent(transform);

        //Notify the game a new object has spawned
        spawnEvent.Raise(newObject);

        //Track the number of objects spawned
        spawnedObjCount++;
    }

    public IEnumerator SpawnEnemiesControl()
    {
        // Corotine used for spawning objects once activated
        while (true) {
            //Exit the corotine if we have spawned the correct number of objects, or infinite for 0
            if (spawnCount != 0 && spawnedObjCount >= spawnCount)
            {
                yield break;
            }

            SpawnObject();
            yield return new WaitForSeconds(spawnDelay);            
        }
    }
}
