using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedController : MonoBehaviour
{
    public Sprite projectileSprite = null;
    public int damage = 0;
    public float falloffTime = 1f;
    public int maxHits = 1;
    public float projectileSpeed = 1f;

    [SerializeField]
    GameObject projectilePrefab = null;

    Camera mainCam;

    public void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mousePos - transform.position;
            GameObject go = ObjectPooler.instance.GetPooledObject(projectilePrefab);
            go.transform.parent = transform;
            go.transform.localPosition = Vector2.zero;
            Projectile p = go.GetComponent<Projectile>();
            p.Launch(dir, projectileSprite, damage, falloffTime, maxHits, projectileSpeed);
        }
    }
}
