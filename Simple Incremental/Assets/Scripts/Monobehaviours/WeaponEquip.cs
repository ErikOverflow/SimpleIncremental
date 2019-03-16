using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleIncremental.Weapon
{
    public class WeaponEquip : MonoBehaviour
    {
        [SerializeField]
        WeaponController weaponController = null;
        [SerializeField]
        GameObject weaponPrefab = null;
        public int maxWeapons = 1;

        public void EquipWeapon(InventoryWeapon weapon)
        {
            if (weaponController.activeWeapons.Count < maxWeapons)
            {
                Weapon newWeapon = null;
                if (weaponController.inactiveWeapons.Count > 0)
                {
                    newWeapon = weaponController.inactiveWeapons.FirstOrDefault();
                    weaponController.inactiveWeapons.Remove(newWeapon);
                }
                else
                {
                    GameObject go = Instantiate(weaponPrefab, weaponController.transform);
                    newWeapon = go.GetComponent<Weapon>();
                }
                newWeapon.GetComponent<WeaponHook>().weaponTemplate = weapon.template;
                //If we have levels or exp on the weapon, update the statAugment for it.
                newWeapon.GetComponent<WeaponStatsSystem>().ApplyAugments();
                newWeapon.gameObject.SetActive(true);
                weaponController.activeWeapons.Add(newWeapon);
            }
        }

        public void UnequipWeapon(GameObject go) //Invoked by calling UnequipWeapon with the gameobject that's holding it.
        {
            Weapon weapon = go.GetComponent<Weapon>();
            weaponController.activeWeapons.Remove(weapon);
            weaponController.inactiveWeapons.Add(weapon);
            go.SetActive(false);
        }
    }
}
