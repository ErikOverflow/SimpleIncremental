using SimpleIncremental.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<Weapon> activeWeapons;
    [SerializeField]
    GameObject weaponPrefab;
    [SerializeField]
    string fireButtonName = "Fire1";

    Camera mainCam = null;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown(fireButtonName))
        {
            Vector2 clickLoc = mainCam.ScreenToWorldPoint(Input.mousePosition);
            foreach(Weapon weapon in activeWeapons)
            {
                weapon.Attack(clickLoc);
            }
        }
    }
}
