using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{


public class EnemyStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;
    Animator animator;
    public GameObject enemy;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Start() {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;    
    }

    public int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return  maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        animator.Play("Damage");

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animator.Play("Death");
            enemy.tag = "Untagged";
            
        }
    }
















 }
}
