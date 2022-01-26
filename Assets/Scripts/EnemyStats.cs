using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{


public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    Animator animator;
    public GameObject enemy;
    public bool isDead;
    EnemyManager enemyManager;
    private void Awake(){
        animator = GetComponent<Animator>();
        enemyManager = GetComponent<EnemyManager>();
    }

    private void Start() {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;    
    }

    public int SetMaxHealthFromHealthLevel()
    {
        maxHealth = 100;
        return  maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(isDead)
        return;
        currentHealth = currentHealth - damage;
        animator.Play("Damage");

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animator.Play("Death");
            // enemy.tag = "Untagged";
            isDead = true;
            enemyManager.enabled= false;
        }
    }
















 }
}
