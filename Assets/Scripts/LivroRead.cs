using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DJD{
public class LivroRead : Interactable
{
    public Sprite BookIcon;

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

        playerManager.BookPopUp.GetComponentInChildren<RawImage>().texture = BookIcon.texture;

        
        playerManager.BookPopUp.SetActive(true);


    }


 }
}
