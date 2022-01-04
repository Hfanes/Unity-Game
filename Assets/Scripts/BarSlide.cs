using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DJD{
public class BarSlide : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void SetCurrentHealth(int currenthealth)
    {
        slider.value = currenthealth;
    }
    public void SetMaxStamina(int maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }
    public void SetCurrentStamina(int currentStamina)
    {
        slider.value = currentStamina;
    }



 }   
}
