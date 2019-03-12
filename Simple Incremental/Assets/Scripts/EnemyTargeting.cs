using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    // All enemy damage types are added here
    [SerializeField]
    List<EnemyDamage> enemyDamage = new List<EnemyDamage>(); 

    // List of gameObjects tagged as player
    List<GameObject> playerTargets = new List<GameObject>(); 

    // List of player objects and best attack for each
    List <PlayerTarget> playerTargetList= new List<PlayerTarget>();

    bool targetListCurrent = false;
    PlayerTarget bestTarget;
    Vector3[] movement = new Vector3[2];

    // Delay for checking movement to avoid checks on every frame
    float movementCheckDelay = 1.0f;
    float elapsedTime;


    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= movementCheckDelay)
        {
            MovementCheck();
            elapsedTime = 0;
        }
    }


    public PlayerTarget FindATarget()
    {
        // Don't recalculate if the list is updated
        if (targetListCurrent)
        {
            return bestTarget;
        }
        else
        {
            PopulateTargetList();

            // Record current enemy position
            movement[0] = transform.position;
            return bestTarget;
        }
    }

    private void PopulateTargetList()
    {
        playerTargets.Clear();
        playerTargetList.Clear();
        playerTargets.AddRange(GameObject.FindGameObjectsWithTag("Player"));

        // Populate the fields for playerTargetList
        foreach (GameObject gameObj in playerTargets)
        {
            if (gameObj.activeSelf)
            {
                PlayerTarget newEntry = new PlayerTarget();
                newEntry.gameObjectRef = gameObj;

                // Distance from enemy to player
                newEntry.distance = Vector3.Distance(transform.position, gameObj.transform.position);

                // Checks all attacks to see which causes the most damage for this player object
                newEntry.enemyAttack = FindBestAttack(newEntry.distance);

                playerTargetList.Add(newEntry);
            }
        }

        // Use the first player target as a starting point, since type is not nullable
        if (playerTargetList.Count > 0)
        {
            bestTarget = playerTargetList[0];
        }

        // Picks the player object that the enemy can inflict the most damage per second on
        foreach (PlayerTarget playerTarget in playerTargetList)
        {
            if (playerTarget.enemyAttack.GetDamagePerSecond() > bestTarget.enemyAttack.GetDamagePerSecond())
            {
                bestTarget = playerTarget;

                // Record current target position
                movement[1] = bestTarget.gameObjectRef.transform.position;
            }
        }
    }

    private EnemyDamage FindBestAttack(float _distance)
    {
        EnemyDamage bestDamage = null;

        foreach (EnemyDamage damageObject in enemyDamage)
        {
            damageObject.CalculateDamagePerSecond();

            if (bestDamage == null && damageObject.attackRange >= _distance)
            {
                bestDamage = damageObject;
            }
            else if (damageObject.attackRange >= _distance && damageObject.GetDamagePerSecond() > 
                bestDamage.GetDamagePerSecond())
            {
                bestDamage = damageObject;
            }
        }

        return bestDamage;
    }

    // Marks the target list as outdated if a player is dead, which forces an update
    public void PlayerDead(GameObject _gameObject)
    {
        if (bestTarget.gameObjectRef == _gameObject)
        {
            targetListCurrent = false;
        }
    }

    // Marks the target list as outdated if a movement is detected. This allows optimized weapon selection
    public void MovementCheck()
    {
        // Check enemy and player target positions
        if (movement[0] != transform.position || movement[1] != bestTarget.gameObjectRef.transform.position)
        {
            targetListCurrent = false;
        }
    }
}


