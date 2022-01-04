using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJD{
public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager WeaponSlotManager;
    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;
    public WeaponItem unarmedWeapon;


    public List<WeaponItem> weaponsInventory;

    private void Awake() {
        WeaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start() {
        WeaponSlotManager.LoadWeaponOnSlot(rightWeapon,false);
        WeaponSlotManager.LoadWeaponOnSlot(leftWeapon,false);
        // WeaponSlotManager.LoadWeaponOnSlot(unarmedWeapon,true);
    }

    











}
}
