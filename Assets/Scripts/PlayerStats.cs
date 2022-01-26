using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currenthealth;
    public BarSlide staminaBar;
    public BarSlide healthBar;

    AnimatorHandler animatorHandler;
    public float currentStamina;
    public float maxStamina;
    public float staminaRegenAmount = 50;
    public float staminaRegenTimer = 0;

    PlayerManager playerManager;
    MenusJogo menusJogo;
    public bool isDead;
    




    private void Awake() {
        healthBar = FindObjectOfType<BarSlide>();
        staminaBar = FindObjectOfType<BarSlide>();

        animatorHandler = GetComponentInChildren<AnimatorHandler>(); 
        playerManager = GetComponent<PlayerManager>();
        menusJogo = FindObjectOfType<MenusJogo>();

    }
    void Start(){
        maxHealth = SetMaxHealthFromHealthLevel();
        currenthealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        maxStamina = SetMaxStaminaFromStaminaLevel();
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        
    }

    private int SetMaxHealthFromHealthLevel(){
        maxHealth = 150;
        return  maxHealth;
    }
    private float SetMaxStaminaFromStaminaLevel(){
        maxStamina  = 150;
        return  maxStamina;
    }

    public void TakeDamage(int damage)
    {
        if(isDead)
        return;
        currenthealth = currenthealth - damage;
        healthBar.SetCurrentHealth(currenthealth);
        animatorHandler.PlayTargetAnimation("Male Damage Light", true);

        if(currenthealth <= 0)
        {
            currenthealth = 0;
            animatorHandler.PlayTargetAnimation("Male Die", true);
            isDead = true;
            //Handle Player Death
            menusJogo.gameOver();


        }
    }
    public void TakeStaminaDamage(float stamina)
    {
        currentStamina = currentStamina - stamina;
        staminaBar.SetCurrentStamina(currentStamina);
    }


    public void RegenStamina(){
        if(playerManager.isInteracting)
        {
            staminaRegenTimer = 0;
        }
        else
        {
            staminaRegenTimer += Time.deltaTime;
            if(currentStamina < maxStamina && staminaRegenTimer > 1f)
            {
                currentStamina += staminaRegenAmount * Time.deltaTime;
                staminaBar.SetCurrentStamina(Mathf.RoundToInt(currentStamina));
            }
        }
        
    }
 }
}
