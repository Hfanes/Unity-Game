using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class WeaponSlotManager : MonoBehaviour
{
    public WeaponItem attackingWeapon;
    PlayerInventory playerInventory;

    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    public DamageCollider lightAttackDamageCollider;
    public DamageCollider heavyAttackDamageCollider;

    PlayerStats playerStats;
    EnemyStats enemy;
    QuickSlotsUI quickSlotsUI;


    private void Awake() {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        playerStats = GetComponentInParent<PlayerStats>();
        playerInventory = GetComponentInParent<PlayerInventory>();
        quickSlotsUI = FindObjectOfType<QuickSlotsUI>();

        foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots) //pecorre o playermodel para ver se é na esq ou direita
        {
            if(weaponSlot.isLeftHandslot)
            {
                leftHandSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
        }    
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if(isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
        }
        else
        rightHandSlot.LoadWeaponModel(weaponItem);
        LoadlightAttackDamageCollider();
        LoadheavyAttackDamageCollider();
        quickSlotsUI.UpdateWeaponIconUI(weaponItem);
    }

    public void LoadlightAttackDamageCollider(){
        lightAttackDamageCollider = rightHandSlot.currentweaponModel.GetComponentInChildren<DamageCollider>();
    }
    public void LoadheavyAttackDamageCollider(){
        heavyAttackDamageCollider = rightHandSlot.currentweaponModel.GetComponentInChildren<DamageCollider>();
    }
    public void OpenlightAttackDamageCollider(){
        lightAttackDamageCollider.currentWeaponDamage = playerInventory.rightWeapon.lightDamage;
        lightAttackDamageCollider.EnableDamageCollider();
    }
    public void OpenheavyAttackDamageCollider(){
        heavyAttackDamageCollider.currentWeaponDamage = playerInventory.rightWeapon.heavyDamage;
        heavyAttackDamageCollider.EnableDamageCollider();
    }
    public void CloselightAttackDamageCollider(){
        lightAttackDamageCollider.DisableDamageCollider();
    }
    public void CloseheavyAttackDamageCollider(){
        heavyAttackDamageCollider.DisableDamageCollider();
    }

    public void DrainStaminaLight(){
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }
    public void DrainStaminaHeavy(){
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }
















 }
}
