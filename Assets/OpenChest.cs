using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD
{
public class OpenChest : Interactable
{
    Animator animator;
    OpenChest openChest;
    public Transform PlayerStandChest;
    public GameObject itemSpawner; 
    public WeaponItem itemInChest;

    private void Awake() {
        animator = GetComponent<Animator>();
        openChest = GetComponent<OpenChest>();
    }
    public override void Interact(PlayerManager playerManager)
    {
        //Rodar o player em direçao ao chest
        Vector3 rotatioDirection = transform.position - playerManager.transform.position;
        rotatioDirection.y = 0;
        rotatioDirection.Normalize();

        Quaternion tr = Quaternion.LookRotation(rotatioDirection);
        Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 300 * Time.deltaTime);
        playerManager.transform.rotation = targetRotation;
        
        //Bloquear em frente ao chest
        playerManager.OpenChestInteraction(PlayerStandChest);

        //open chest/animaçao
        animator.Play("ChestOpen");



        //spawn item dentro para apanhar
        StartCoroutine(SpawnItemInChest());
        itemSpawner.SetActive(true);

        // itemSpawner.transform.position = PlayerStandChest.transform.position;

        // WeaponPickUp weaponPickUp = itemSpawner.GetComponent<WeaponPickUp>();
        // if(weaponPickUp != null)
        // {
        //     weaponPickUp.weapon = itemInChest;
        // }

    }

    private IEnumerator SpawnItemInChest(){
        yield return new WaitForSeconds(1f);
        // Instantiate(itemSpawner);
        Destroy(openChest);
    }



 }   
}
