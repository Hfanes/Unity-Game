using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DJD{
public class OpenDoor : Interactable
{
    public override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);
        Open(playerManager);
    }


    private void Open(PlayerManager playerManager)
    {
        PlayerMovement playerMovement;
        // AnimatorHandler animatorHandler;
        Animator animator;
        
        playerMovement = playerManager.GetComponent<PlayerMovement>();
        // animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();
        animator = GetComponent<Animator>();


        animator.SetTrigger("OpenDoor");     


    }



 }
}
