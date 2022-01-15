using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJD{
public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;
    public bool b_Input;
    public bool LightAttack_Input;
    public bool HeavyAttack_Input;
    public bool Use_Input;
    public bool jump_Input;
    public bool e_Input;



    
    public bool rollFlag;
    public float rollInputTimer;
    public bool sprintFlag;

    PlayerControls  inputActions;
    PlayerAttacker playerAttacker;
    Vector2 movementInput;
    Vector2 cameraInput;
    PlayerMovement playerMovement;

    private void Awake(){
        playerAttacker = GetComponent<PlayerAttacker>();
    }




    public void OnEnable(){
        if(inputActions == null){
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            inputActions.PlayerActions.LightAttack.performed += i => LightAttack_Input = true;
            inputActions.PlayerActions.HeavyAttack.performed += i => HeavyAttack_Input = true;
            inputActions.PlayerActions.Jump.performed += i => jump_Input = true;
            inputActions.PlayerActions.E.performed += i => e_Input = true;        



        }
        inputActions.Enable(); 
    }

    private void OnDisable() {
        inputActions.Disable();
    }

    public void TickInput(float delta){
        MoveInput(delta);
        HandleRollInput(delta);
        HandleAttackInput(delta);
    }
    
    private void MoveInput(float delta){
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void HandleRollInput(float delta){
        b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if(b_Input){
            rollInputTimer += delta;
            sprintFlag = true;
        }
        else{
            if(rollInputTimer > 0 && rollInputTimer <0.5f){
                sprintFlag = false;
                rollFlag = true;
            }
            rollInputTimer = 0;
        }
    }

    private void HandleAttackInput(float delta){
        if(LightAttack_Input)
        {
            playerAttacker.HandleLightAttack(playerAttacker.weapon);
        }
        if(HeavyAttack_Input)
        {
            playerAttacker.HandleHeavyAttack(playerAttacker.weapon);
        }
    }































}
} 
