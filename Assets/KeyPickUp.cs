using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DJD{
public class KeyPickUp : Interactable 
{

    public GameObject key;
    private Key chave;
    QuickSlotsUI quickSlotsUI;

    private void Awake() {
        chave = GetComponent<Key>();
        quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
    }
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
        // playerInventory.keyList.Add(Key.KeyType.Silver);
        playerInventory.AddKey(chave.GetKeyType());


        if(chave.GetKeyType().ToString() == "Silver")
        {
        playerManager.ItemPopUp.GetComponentInChildren<Text>().text = chave.GetKeyType().ToString();

            playerManager.ItemPopUp.GetComponentInChildren<RawImage>().texture = chave.SilverIcon.texture;
            quickSlotsUI.UpdateKeyIconUI(chave);

        }
        else{
        playerManager.ItemPopUp.GetComponentInChildren<Text>().text = chave.GetKeyType().ToString();

            playerManager.ItemPopUp.GetComponentInChildren<RawImage>().texture = chave.GoldIcon.texture;
            quickSlotsUI.UpdateKeyIconUI(chave);

        }
        playerManager.ItemPopUp.SetActive(true);
        Destroy(gameObject);

    }









 }
}
