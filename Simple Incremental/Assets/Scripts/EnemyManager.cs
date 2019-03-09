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
}
