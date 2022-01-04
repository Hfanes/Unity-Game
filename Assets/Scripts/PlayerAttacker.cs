using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJD{


public class PlayerAttacker : MonoBehaviour
{

    public WeaponItem weapon;

    AnimatorHandler animatorHandler;
    WeaponSlotManager weaponSlotManager;


    private void Awake(){
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }
    public void HandleLightAttack(WeaponItem weapon){
        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
        
    }

    public void HandleHeavyAttack(WeaponItem weapon){
        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
        
    
    }

    









}
}
