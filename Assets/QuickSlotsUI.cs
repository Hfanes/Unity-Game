using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace DJD{
public class QuickSlotsUI : MonoBehaviour
{   
    public Image rightWeaponIcon;


    public void UpdateWeaponIconUI(WeaponItem weaponItem){

        if(weaponItem.itemIcon != null) //se tiver imagem 
        {
            rightWeaponIcon.sprite = weaponItem.itemIcon;
            rightWeaponIcon.enabled = true;
        }
        else
        {
            rightWeaponIcon.sprite = null;
            rightWeaponIcon.enabled = false;
        }
        
    }   
    


 }    
}
