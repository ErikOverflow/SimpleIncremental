using SimpleIncremental.Weapon;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<GameObject> activeWeapons;
    public List<GameObject> inactiveWeapons;
    [SerializeField]
    string fireButtonName = "Fire1";

    Camera mainCam = null;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        foreach(GameObject weapon in activeWeapons)
        {
            weapon.SetActive(true);
        }
        foreach (GameObject weapon in inactiveWeapons)
        {
            weapon.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown(fireButtonName))
        {
            Vector2 clickLoc = mainCam.ScreenToWorldPoint(Input.mousePosition);
            foreach(GameObject weapon in activeWeapons)
            {
                weapon.GetComponents<Weapon>().FirstOrDefault(w => w.active)?.Attack(clickLoc);
            }
        }
    }
}
