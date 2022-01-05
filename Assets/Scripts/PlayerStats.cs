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
    public int currentStamina;
    public int staminaLevel = 10;
    public int maxStamina;



    private void Awake() {
        healthBar = FindObjectOfType<BarSlide>();
        staminaBar = FindObjectOfType<BarSlide>();

        animatorHandler = GetComponentInChildren<AnimatorHandler>(); 
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
    private int SetMaxStaminaFromStaminaLevel(){
        maxStamina  = staminaLevel * 10;
        return  maxStamina;
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

    public void TakeStaminaDamage(int damage)
    {
        currentStamina = currentStamina - damage;
        staminaBar.SetCurrentStamina(currentStamina);

    }

















 }
}
