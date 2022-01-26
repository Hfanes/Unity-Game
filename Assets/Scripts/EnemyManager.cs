using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class EnemyManager : MonoBehaviour
{
    public bool isPreformingAction;
    EnemyMovement enemyMovement;
    
    [Header ("A.I Settings")]
    public float detectionRadius = 5;
    //Quanto maior e menor estes vvalores maior será a deteçao do enemigo
    public float maximumDetectionAngle = 30;
    public float minimumDetectionAngle = -30;
    public float currentRecoveryTime = 0;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    AnimatorHandler animatorHandler;
    EnemyAnimatorManager enemyAnimatorManager;
    PlayerStats playerStats;
    EnemyStats enemyStats;



    
    private void Awake() {
        enemyMovement = GetComponent<EnemyMovement>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        enemyStats = FindObjectOfType<EnemyStats>();
    }

    private void Update() {
    }

    private void FixedUpdate() {   
        HandleCurrentAction();
        HandleRecoveryTimer();
    }


    private void HandleCurrentAction(){
        if(enemyStats.isDead)
        {
            return;
        }
        if(playerStats.isDead == false && enemyStats.isDead == false)
        {
            if(enemyMovement.currentTarget != null)
            {
             enemyMovement.distanceFromTarget = Vector3.Distance(enemyMovement.currentTarget.transform.position, transform.position);
            }
            if(enemyMovement.currentTarget == null)
            {
                enemyMovement.HandleDetection();
            }
            else if(enemyMovement.distanceFromTarget >= enemyMovement.stoppingDistance)
            {
                enemyMovement.HandleRotatioTowardsTarget();
                enemyMovement.HandleMoveToTarget();
            }
            else if(enemyMovement.distanceFromTarget <= enemyMovement.stoppingDistance)
            {
                if(enemyStats.isDead)
        {
            return;
        }
                enemyMovement.HandleRotatioTowardsTarget();
                AttackTarget();
            }
        }
        else
        {
            return;
        }
        
    }

    private void GetNewAttack(){
        if(enemyStats.isDead)
        {
            return;
        }
        Vector3 targetsDirection = enemyMovement.currentTarget.transform.position - transform.position; 
        float viewableAngle = Vector3.Angle(targetsDirection, transform.forward);
        enemyMovement.distanceFromTarget = Vector3.Distance(enemyMovement.currentTarget.transform.position, transform.position);

        int maxScore = 0;
        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if(enemyMovement.distanceFromTarget <= enemyAttackAction.maximumDistanceNeededAttack && 
            enemyMovement.distanceFromTarget >= enemyAttackAction.minimumDistanceNeededAttack)
            {
                if(viewableAngle <= enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    maxScore += enemyAttackAction.attackScore; 
                }
            }
        }

        int randomValue = Random.Range(0, maxScore);
        int temporaryScore = 0;
        
        for(int i = 0; i< enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if(enemyMovement.distanceFromTarget <= enemyAttackAction.maximumDistanceNeededAttack && 
            enemyMovement.distanceFromTarget >= enemyAttackAction.minimumDistanceNeededAttack)
            {
                if(viewableAngle <= enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    if(currentAttack != null)
                    {
                        return;
                    }
                    temporaryScore += enemyAttackAction.attackScore;
                    if(temporaryScore > randomValue)
                    {
                        currentAttack = enemyAttackAction;
                    }
                }
            }
        }
    }

    
    private void AttackTarget(){
        if(enemyStats.isDead)
        {
            return;
        }

        if(isPreformingAction)
        {
            return;
        }
        if (currentAttack == null)
        {
            GetNewAttack();
        }
        else
        {
            isPreformingAction = true;
            currentRecoveryTime = currentAttack.recoveryTime;
            //animação
            enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
            currentAttack = null;
        }
    }
    
    private void HandleRecoveryTimer(){
        if(enemyStats.isDead)
        {
            return;
        }
        if(currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if(isPreformingAction)
        {
            if(currentRecoveryTime <= 0)
            {
                isPreformingAction = false;
            }
        }
    }


    



 }
}
