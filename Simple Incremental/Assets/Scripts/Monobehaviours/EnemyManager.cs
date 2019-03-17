using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<CharacterHealth> enemies;

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

    public void RemoveEnemy(GameObject go)
    {
        enemies.Remove(go.GetComponent<CharacterHealth>());
    }

    public void AddEnemy(GameObject go)
    {
        enemies.Add(go.GetComponent<CharacterHealth>());
    }
}
