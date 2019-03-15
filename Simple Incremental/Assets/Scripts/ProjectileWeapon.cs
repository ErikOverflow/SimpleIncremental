using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab = null;
    [SerializeField]
    string fireButtonName = "Fire1";

    SpriteRenderer spriteRenderer = null;

    public Sprite projectileSprite = null;
    public float projectileSpeed = 1f;
    public int maxPenetrations = 1;
    public float projectileModifier = 1f;
    public float falloffTime = 1f;
    public int damage = 1;
    public float reloadSpeed = 1f;
    Camera mainCam = null;
    Queue<Projectile> projectiles = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
    }

    private void Start()
    {
        projectiles = ProjectileManager.instance.projectiles;
    }

    void Update()
    {
        if (Input.GetButtonDown(fireButtonName))
        {
            Vector2 clickLoc = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Projectile p = null;
            if (projectiles.Count > 0)
            {
                p = projectiles.Dequeue();
                p.transform.position = transform.position;
            }
            else
            {
                GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity, ProjectileManager.instance.transform);
                p = go.GetComponent<Projectile>();
            }
            p.Launch(clickLoc - (Vector2)transform.position, projectileSprite, damage, falloffTime, maxPenetrations, projectileSpeed);
        }
    }
}
