using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<CharacterHealth> enemies;
    public GameObject enemyPrefab;
    public float spawnWidth;
    public float spawnHeight;


    [SerializeField]
    GameEvent spawnEvent = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            enemies = GetComponentsInChildren<CharacterHealth>().ToList();
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemiesControl());
    }

    public void AddEnemy(GameObject go)
    {
        enemies.Add(go.GetComponent<CharacterHealth>());
    } 	
    public void SpawnEnemy()
    {
        //Spawn a new enemy at a random location 
        Vector3 randomRange;
        Vector3 origin = transform.position;

        //Force the spawn to happen at the edge of the screen
        switch(Random.Range(0, 4))
        {
            case 0:
                randomRange = new Vector3(spawnWidth, Random.Range(-spawnHeight, spawnHeight), 0);
                break;
            case 1:
                randomRange = new Vector3(-spawnWidth, Random.Range(-spawnHeight, spawnHeight), 0);
                break;
            case 2:
                randomRange = new Vector3(Random.Range(-spawnWidth, spawnWidth), spawnHeight, 0);
                break;
            default:
                randomRange = new Vector3(Random.Range(-spawnWidth, spawnWidth), -spawnHeight, 0);
                break;
        }

        //Offset the spawn by the origin location of the Enemy Container
        Vector3 randomCoordinate = origin + randomRange;

        //Spawn the new enemy and add him the enemies list
        GameObject newEnemy = Instantiate(enemyPrefab, randomCoordinate, Quaternion.identity);
        enemies.Add(newEnemy.GetComponent<CharacterHealth>());
    }
    public void RemoveEnemy(GameObject go)
    {
        //Remove the enemy from active enemies list
        enemies.Remove(go.GetComponent<CharacterHealth>());
        //Destroy the object so that the targeting system targets new enemy
        Destroy(go);
    }

    public IEnumerator SpawnEnemiesControl()
    {
        while (true)
        {
            // Spawn enemies after a period of time.
            yield return new WaitForSeconds(10);
            //Spawn a new enemy
            spawnEvent.Raise();
        }
    }
}
