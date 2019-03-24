﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleIncremental.Weapon
{
    public class ProjectileWeapon : Weapon
    {
        [SerializeField]
        GameObject projectilePrefab = null;

        public SpriteRenderer spriteRenderer = null;
        public Sprite projectileSprite = null;
        public float projectileSpeed = 1f;
        public int maxPenetrations = 1;
        public float falloffTime = 1f;
        Queue<Projectile> projectiles = null;

        [SerializeField]
        LayerMask layer;
        private int layerNum;

        public void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            layerNum = Mathf.RoundToInt(Mathf.Log(layer.value, 2));
            projectiles = ProjectileManager.instance.projectiles;
        }

        public override void Attack(Vector2 target)
        {
            Projectile p = null;
            if (projectiles.Count > 0)
            {
                p = projectiles.Dequeue();
                p.transform.position = transform.position;
                p.transform.rotation = transform.rotation;
            }
            else
            {
                GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity, ProjectileManager.instance.transform);
                p = go.GetComponent<Projectile>();
            }
            p.gameObject.layer = layerNum;
            p.Launch(target - (Vector2)transform.position, projectileSprite, damage, falloffTime, maxPenetrations, projectileSpeed);
        }
    }
}