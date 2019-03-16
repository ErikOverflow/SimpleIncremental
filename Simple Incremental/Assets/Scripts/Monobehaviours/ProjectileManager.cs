using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;
    public Queue<Projectile> projectiles = null;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            projectiles = new Queue<Projectile>();
        }
        else
        {
            Destroy(this);
        }
    }
}
