using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJD{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        PlayerMovement playerMovement;
        AnimatorHandler animatorHandler;

        PlayerStats playerStats;
        InteractableUI interactableUI;
        [Header("PickUp")]
        public GameObject InteractionPopUp;
        public GameObject ItemPopUp;
        [Header("ReadBook")]
        public GameObject InteractionBookPopUp;
        public GameObject BookPopUp;


        public Animator anim;
        public bool isInteracting;
        CameraHandler cameraHandler;
        [Header("Player Flags")]
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;





        private void Awake() {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }

        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
            playerMovement = GetComponent<PlayerMovement>();
            interactableUI = FindObjectOfType<InteractableUI>();
            playerStats = GetComponent<PlayerStats>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();

        }

        void Update()
        {

            float delta = Time.deltaTime;
            isInteracting = anim.GetBool("isInteracting");
            anim.SetBool("isInAir",isInAir);       

            inputHandler.TickInput(delta);
            playerMovement.HandleMovement(delta);
            playerMovement.HandleRollingAndSprinting(delta);
            playerMovement.HandleFalling(delta, playerMovement.moveDirection);
            playerMovement.HandleJumping(delta);

            playerStats.RegenStamina();  

            CheckForInteractableObject();
            ReadBook();
            Open();
            
        }

        

        private void FixedUpdate() {
            float delta = Time.fixedDeltaTime;  
            
        }

        private void LateUpdate() { //so poder ser clicado ou feito uma vez por frame
            inputHandler.rollFlag = false;
            inputHandler.sprintFlag = false;
            inputHandler.LightAttack_Input = false;
            inputHandler.HeavyAttack_Input = false;
            inputHandler.jump_Input = false;
            inputHandler.e_Input = false;


            float delta = Time.fixedDeltaTime;    
            if(cameraHandler != null){
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }

            if (isInAir){
                playerMovement.inAirTimer = playerMovement.inAirTimer + Time.deltaTime;
            }

        }

        public void CheckForInteractableObject(){
            RaycastHit hit;
            if(Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f, cameraHandler.ignoreLayers)){
                if(hit.collider.tag == "Interactable")
                {
                    Interactable interactableOject = hit.collider.GetComponent<Interactable>();
                    if(interactableOject != null)
                    {
                        string interactableText = interactableOject.interacatbleText;
                        //UI 
                        //POP up
                        interactableUI.interactableText.text = interactableText;
                        InteractionPopUp.SetActive(true);
                        if(inputHandler.e_Input)
                        {
                            hit.collider.GetComponent<Interactable>().Interact(this);
                        }
                    }
                }
            }
            else
            {
                if(InteractionPopUp != null)
                {
                    InteractionPopUp.SetActive(false); //Se sair da zona o pop up desparece
                }

                if(ItemPopUp != null && inputHandler.e_Input)
                {
                    ItemPopUp.SetActive(false);
                }
            }

        }

        public void ReadBook(){
            RaycastHit hit;
            if(Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f, cameraHandler.ignoreLayers)){
                if(hit.collider.tag == "Book")
                {
                    Interactable interactableOject = hit.collider.GetComponent<Interactable>();
                    if(interactableOject != null)
                    {
                        string interactableBookText = interactableOject.interacatbleText;
                        //UI 
                        //POP up
                        interactableUI.interactableBookText.text = interactableBookText;
                        InteractionBookPopUp.SetActive(true);

                        if(inputHandler.e_Input)
                        {
                            hit.collider.GetComponent<Interactable>().Interact(this);
                        }
                    }
                }
            }
            else
            {
                if(InteractionBookPopUp != null)
                {
                    InteractionBookPopUp.SetActive(false); //Se sair da zona o pop up desparece
                }

                if(BookPopUp != null && inputHandler.e_Input)
                {
                    BookPopUp.SetActive(false);
                }
            }


        }

        public void Open(){
            RaycastHit hit;
            if(Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f, cameraHandler.ignoreLayers)){
                if(hit.collider.tag == "Interactable")
                {
                    Interactable interactableOject = hit.collider.GetComponent<Interactable>();
                    if(interactableOject != null)
                    {

                        if(inputHandler.e_Input)
                        {
                            hit.collider.GetComponent<Interactable>().Interact(this);
                        }
                    }
                }
            }
            else
            {
                // if(InteractionBookPopUp != null)
                // {
                //     InteractionBookPopUp.SetActive(false); //Se sair da zona o pop up desparece
                // }

                // if(BookPopUp != null && inputHandler.e_Input)
                // {
                //     BookPopUp.SetActive(false);
                // }
            }


        }

        public void OpenChestInteraction(Transform PlayerStandChest)
        {
            playerMovement.rigidbody.velocity = Vector3.zero; //para o jogador
            transform.position = PlayerStandChest.transform.position;
            animatorHandler.PlayTargetAnimation("Chest Open", true);

        }

        



    }
}

