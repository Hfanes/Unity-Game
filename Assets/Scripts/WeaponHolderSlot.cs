using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentoverride;
    public bool isRightHandSlot;
    public GameObject currentweaponModel;

    public void UnloadWeapon(){
        if(currentweaponModel != null){
            currentweaponModel.SetActive(false);
        }
    }

    public void UnloadWeaponAndDestroy(){
        if(currentweaponModel != null){
            Destroy(currentweaponModel);
        }
    }


    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        //UnloadweaponAndDestroy
        UnloadWeaponAndDestroy();
        if(weaponItem == null)
        {
            UnloadWeapon();
            return;
        }
        GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject; 

        if(model != null)
        {
            if(parentoverride != null)
            {
                model.transform.parent = parentoverride;
            }
            else{
                model.transform.parent = transform;
            }

            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }
        currentweaponModel = model;
    }

    
    
 
 }
}
