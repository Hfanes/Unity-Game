using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJD{
public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager WeaponSlotManager;
    public WeaponItem rightWeapon;
    public WeaponItem unarmedWeapon;


    public List<WeaponItem> weaponsInventory;

    private void Awake() {
        WeaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start() {
        WeaponSlotManager.LoadWeaponOnSlot(rightWeapon);

        // WeaponSlotManager.LoadWeaponOnSlot(unarmedWeapon,true);
    }
    

    public void ChangeOnPickUp()
    {
        rightWeapon = weaponsInventory[0];
        WeaponSlotManager.LoadWeaponOnSlot(weaponsInventory[0]);

    }

    











}
}
