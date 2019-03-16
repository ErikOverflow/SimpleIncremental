using SimpleIncremental.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<Weapon> activeWeapons;
    public List<Weapon> inactiveWeapons;
    [SerializeField]
    string fireButtonName = "Fire1";

    Camera mainCam = null;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        foreach(Weapon weapon in activeWeapons)
        {
            weapon.gameObject.SetActive(true);
        }
        foreach (Weapon weapon in inactiveWeapons)
        {
            weapon.gameObject.SetActive(false);
        }
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
