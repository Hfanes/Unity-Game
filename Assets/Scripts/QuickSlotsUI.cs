using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace DJD{
public class QuickSlotsUI : MonoBehaviour
{   
    public Image rightWeaponIcon;
    public Image keyIcons;


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
    
    public void UpdateKeyIconUI(Key key){
        if(key.GetKeyType().ToString() == "Silver")
        {
            if(key.SilverIcon != null) //se tiver imagem 
            {
                keyIcons.sprite = key.SilverIcon;
                keyIcons.enabled = true;
            }
            else
            {
                keyIcons.sprite = null;
                keyIcons.enabled = false;
            }
        }
        else
        {
            if(key.GoldIcon != null) //se tiver imagem 
        {
            keyIcons.sprite = key.GoldIcon;
            keyIcons.enabled = true;
        }
        else
        {
            keyIcons.sprite = null;
            keyIcons.enabled = false;
        }
        }

        
    }  


 }    
}
