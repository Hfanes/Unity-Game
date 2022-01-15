using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currenthealth;
    public BarSlide staminaBar;
    public BarSlide healthBar;

    AnimatorHandler animatorHandler;
    public float currentStamina;
    public int staminaLevel = 10;
    public float maxStamina;
    public float staminaRegenAmount = 30;
    public float staminaRegenTimer = 0;

    PlayerManager playerManager;




    private void Awake() {
        healthBar = FindObjectOfType<BarSlide>();
        staminaBar = FindObjectOfType<BarSlide>();

        animatorHandler = GetComponentInChildren<AnimatorHandler>(); 
        playerManager = GetComponent<PlayerManager>();
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
        maxHealth = healthLevel * 10;
        return  maxHealth;
    }
    private float SetMaxStaminaFromStaminaLevel(){
        maxStamina  = staminaLevel * 10;
        return  maxStamina;
    }

    private void OnTriggerEnter(Collider other) { //Damage do inimigo (ainda nao ta a funcionar)
        if(other.gameObject.tag == "Enemy Sword"){
             PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if(playerStats != null){
                playerStats.TakeDamage(10);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currenthealth = currenthealth - damage;
        healthBar.SetCurrentHealth(currenthealth);
        animatorHandler.PlayTargetAnimation("Male Damage Light", true);

        if(currenthealth <= 0)
        {
            currenthealth = 0;
            animatorHandler.PlayTargetAnimation("Male Die", true);
            //Handle Player Death
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
