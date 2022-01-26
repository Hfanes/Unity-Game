using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class EnemyDamage : MonoBehaviour
{
    public WeaponItem weaponItem; 
    WeaponHolderSlot sword;
    DamageCollider damageCollider;

    private void Awake() {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots) //pecorre o playermodel para ver se é na esq ou direita
        {
            if (weaponSlot.isRightHandSlot)
            {
                sword = weaponSlot;
            }
        }  
    }

    private void Start() {
        if(weaponItem != null)
        {
            LoadWeapon(weaponItem);
        }
    }
    public void LoadWeapon(WeaponItem weapon)
    {
        sword.LoadWeaponModel(weapon);
        LoadWeaponDamageCollider();
    }

    public void LoadWeaponDamageCollider()
    {
        damageCollider = sword.currentweaponModel.GetComponentInChildren<DamageCollider>();
    }

    public void OpenDamageCollider(){
        damageCollider.EnableDamageCollider();

    }
    
    public void CloseDamageCollider(){
        damageCollider.DisableDamageCollider();
    }


 }
}
