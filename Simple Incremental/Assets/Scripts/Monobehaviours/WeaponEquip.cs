using SimpleIncremental.Inventory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleIncremental.Weapon
{
    public class WeaponEquip : MonoBehaviour
    {
        WeaponController weaponController = null;
        [SerializeField]
        GameObject weaponPrefab = null;
        public int maxWeapons = 1;

        private void Awake()
        {
            weaponController = GetComponent<WeaponController>();
        }

        private void Start()
        {
            EquipActiveWeapons();
        }

        public void EquipActiveWeapons()
        {
            weaponController.inactiveWeapons.AddRange(weaponController.activeWeapons);
            foreach(GameObject go in weaponController.activeWeapons)
            {
                go.SetActive(false);
            }
            weaponController.activeWeapons.Clear();
            foreach (InventoryWeapon invWeapon in PlayerInventory.instance.weapons.Where(w => w.equipped))
            {
                EquipWeapon(invWeapon);
            }
        }

        private void EquipWeapon(InventoryWeapon weapon)
        {
            if (weaponController.activeWeapons.Count < maxWeapons)
            {
                GameObject go = null;
                if (weaponController.inactiveWeapons.Count > 0)
                {
                    go = weaponController.inactiveWeapons.FirstOrDefault();
                    weaponController.inactiveWeapons.Remove(go);
                }
                else
                {
                    go = Instantiate(weaponPrefab, weaponController.transform);
                    Weapon[] weapons = go.GetComponents<Weapon>();
                    foreach(Weapon weap in weapons)
                    {
                        weap.active = false;
                    }
                }
                go.GetComponent<WeaponHook>().weaponTemplate = weapon.template;
                //If we have levels or exp on the weapon, update the statAugment for it.
                go.GetComponent<WeaponStatsSystem>().ApplyAugments();
                go.gameObject.SetActive(true);
                weaponController.activeWeapons.Add(go);
            }
        }

        public void UnequipWeapon(GameObject go) //Invoked by calling UnequipWeapon with the gameobject that's holding it.
        {
            weaponController.activeWeapons.Remove(go);
            weaponController.inactiveWeapons.Add(go);
            go.SetActive(false);
        }
    }
}
