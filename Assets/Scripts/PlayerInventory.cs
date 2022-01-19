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
    public List<Key.KeyType> keyList;


    private void Awake() {
        WeaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        keyList = new List<Key.KeyType>();
    }

    private void Start() {
        WeaponSlotManager.LoadWeaponOnSlot(rightWeapon);

        // WeaponSlotManager.LoadWeaponOnSlot(unarmedWeapon,true);
    }
    

    public void ChangeOnPickUp()
    {
        rightWeapon = weaponsInventory[weaponsInventory.Count -1];
        WeaponSlotManager.LoadWeaponOnSlot(weaponsInventory[weaponsInventory.Count -1]);
        
    }

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
    }

     public void RemoveKey(Key.KeyType keyType)
     {
         keyList.Remove(keyType);
     }
     public bool ContainsKey(Key.KeyType keyType)
     {
         return keyList.Contains(keyType);
     }

     private void OnTriggerEnter(Collider other) {
        //  Key key = other.GetComponent<Key>();
        //  if(key != null)
        //  {
        //      AddKey(key.GetKeyType());
        //      Destroy(key.gameObject);
        //  }

         KeyDoor keyDoor = other.GetComponent<KeyDoor>();
         if(keyDoor !=null)
         {
             if(ContainsKey(keyDoor.GetKeyType()))
             {
                 //temos a chave necessaria
                 RemoveKey(keyDoor.GetKeyType());
                 keyDoor.OpenDoor();
             }
         }
     }












}
}
