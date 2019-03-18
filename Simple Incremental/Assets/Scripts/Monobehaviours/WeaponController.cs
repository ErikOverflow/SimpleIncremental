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
        activeWeapons = new List<GameObject>();
        inactiveWeapons = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetButtonDown(fireButtonName) && Time.timeScale > 0)
        {
            Vector2 clickLoc = mainCam.ScreenToWorldPoint(Input.mousePosition);
            foreach (GameObject weapon in activeWeapons)
            {
                weapon.GetComponents<Weapon>().FirstOrDefault(w => w.active)?.Attack(clickLoc);
            }
        }
    }
}
