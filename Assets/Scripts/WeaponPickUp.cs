using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DJD{


public class WeaponPickUp : Interactable 
{

    public WeaponItem weapon;
    public override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);

        //Apanhar e adicionar ao inventario
        PickUpItem(playerManager);
    }


    private void PickUpItem(PlayerManager playerManager)
    {
        PlayerMovement playerMovement;
        PlayerInventory playerInventory;
        AnimatorHandler animatorHandler;

        playerInventory = playerManager.GetComponent<PlayerInventory>();
        playerMovement = playerManager.GetComponent<PlayerMovement>();
        animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();


        playerMovement.rigidbody.velocity = Vector3.zero; //parar quando se esta a apanhar o inventario
        animatorHandler.PlayTargetAnimation("Pick Up Item", true);
        playerInventory.weaponsInventory.Add(weapon);
        playerInventory.ChangeOnPickUp();
        playerManager.ItemPopUp.GetComponentInChildren<Text>().text = weapon.itemName;
        playerManager.ItemPopUp.GetComponentInChildren<RawImage>().texture = weapon.itemIcon.texture;
        playerManager.ItemPopUp.SetActive(true);
        Destroy(gameObject);

    }









 }
}
