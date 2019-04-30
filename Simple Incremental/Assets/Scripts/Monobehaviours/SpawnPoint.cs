using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Spawn point is used in conjunction with the TriggerPoint to spawn new objects
 * When a trigger event is seen it will invoke this method to spawn objects
 * via the configured manner.*/
public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    protected private GameObject objectPrefab; //Object that will be spawned
    [SerializeField]
    protected private int maximumSpawns; //Number of Objects to Spawn, 0 for infinite
    [SerializeField]
    protected private int spawnDelay; //Time in seconds to wait before spawning next object
    [SerializeField]
    protected private Trigger[] triggers;

    bool spawning = false;
    [SerializeField]
    EnemyTemplate enemyTemplate = null; //Default functionality is to spawn enemies. Override spawnObject to change this

    protected private int spawnCount = 0;

    public void Start()
    {
        foreach(Trigger trigger in triggers)
        {
            trigger.OnTriggered += StartSpawning;
        }
    }

    public void StartSpawning(GameObject go)
    {
        //Rather than compare the player tag, we will create a spawn layer and change the physics settings to only allow players to collide with them.
        if(!spawning)
            StartCoroutine(SpawnObjectRoutine());
    }

    public virtual void SpawnObject()
    {
        GameObject newObject = ObjectPooler.instance.GetPooledObject(objectPrefab);
        newObject.transform.SetParent(transform);
        newObject.transform.localPosition = Vector3.zero;
        newObject.GetComponent<EnemyHook>().enemyTemplate = enemyTemplate;
        newObject.GetComponent<EnemyStatsSystem>().ApplyAugments();
        newObject.SetActive(true);
        spawnCount++;
    }

    public IEnumerator SpawnObjectRoutine()
    {
        spawning = true;
        while (spawnCount < maximumSpawns || maximumSpawns == 0) {
            SpawnObject();
            yield return new WaitForSeconds(spawnDelay);            
        }
        spawning = false;
    }
}
