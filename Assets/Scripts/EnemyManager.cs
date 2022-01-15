using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class EnemyManager : MonoBehaviour
{
    public bool isPreformingAction;
    EnemyMovement enemyMovement;
    
    [Header ("A.I Settings")]
    public float detectionRadius = 20;
    //Quanto maior e menor estes vvalores maior será a deteçao do enemigo
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    public float currentRecoveryTime = 0;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    AnimatorHandler animatorHandler;
    EnemyAnimatorManager enemyAnimatorManager;



    
    private void Awake() {
        enemyMovement = GetComponent<EnemyMovement>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
    }

    private void Update() {
    }

    private void FixedUpdate() {   
        HandleCurrentAction();

        HandleRecoveryTimer();
    }


    private void HandleCurrentAction(){
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
            enemyMovement.HandleMoveToTarget();
        }
        else if(enemyMovement.distanceFromTarget <= enemyMovement.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void GetNewAttack(){
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
            enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
            currentAttack = null;
        }
    }
    
    private void HandleRecoveryTimer(){
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
