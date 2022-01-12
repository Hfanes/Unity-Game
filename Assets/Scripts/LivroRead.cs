using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DJD{
public class LivroRead : Interactable
{
    public override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);
        ReadBook(playerManager);
    }


    private void ReadBook(PlayerManager playerManager)
    {
        PlayerMovement playerMovement;
        AnimatorHandler animatorHandler;
        
        playerMovement = playerManager.GetComponent<PlayerMovement>();
        animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();


        playerMovement.rigidbody.velocity = Vector3.zero; //parar quando se esta a apanhar o inventario
        animatorHandler.PlayTargetAnimation("Pick Up Item", true);
        playerManager.BookPopUp.GetComponentInChildren<Text>().text = "Historia Maravilhosa";
        
        playerManager.BookPopUp.SetActive(true);


    }


 }
}
