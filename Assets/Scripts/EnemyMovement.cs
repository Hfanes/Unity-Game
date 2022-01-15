using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



namespace DJD{
public class EnemyMovement : MonoBehaviour
{
    EnemyManager enemyManager;
    public LayerMask detectionLayer;
    public PlayerStats currentTarget;
    Animator animator;
    NavMeshAgent navMeshAgent;
    public float distanceFromTarget;
    public float stoppingDistance = 2f;
    public float rotationSpeed = 15;
    public Rigidbody enemyRigidbody;
    EnemyStats enemyStats;
    EnemyAnimatorManager enemyAnimatorManager;

    


    private void Awake() {
        enemyManager = GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyStats = GetComponent<EnemyStats>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();

    }

    private void Start() {
        navMeshAgent.enabled = true;
        enemyRigidbody.isKinematic = false;
    }
    public void HandleDetection()
    {
        //transform.position = posiçao do enemigo
        //detectionLayer para ser so aquele layer que tem que procurar
        Collider [] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer); 
        //procura por um que tenha o PlayerStats
        for(int i=0; i < colliders.Length;  i++)
        {
            PlayerStats playerStats = colliders[i].transform.GetComponent<PlayerStats>();

            if(playerStats != null)
            {
                Vector3 targetDirection = playerStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if(viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    currentTarget = playerStats;
                }

            }
        }
    }

    public void HandleMoveToTarget(){
        if(enemyManager.isPreformingAction)
        return;
        
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        if(enemyStats.currentHealth > 0)
        {
        //se tiver a fazer algo parar o movimento
        if(enemyManager.isPreformingAction)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);

            navMeshAgent.enabled = false;
        }
        else{
            if(distanceFromTarget > stoppingDistance)
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                targetDirection.Normalize();
                targetDirection.y = 0;
                float speed = 2;
                targetDirection *= speed;
                Vector3 projectedVelocity = Vector3.ProjectOnPlane(targetDirection, Vector3.up);
                enemyRigidbody.velocity = projectedVelocity;
            }
            else if(distanceFromTarget < stoppingDistance)
            {

                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            }
        }

        HandleRotatioTowardsTarget();
        }
        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.transform.localRotation = Quaternion.identity;
    }

    private void HandleRotatioTowardsTarget(){
        //rotate normal
        if(enemyManager.isPreformingAction)
        {
            Vector3 direction = currentTarget.transform.position -transform.position;
            direction.y = 0;
            direction.Normalize();

            if(direction == Vector3.zero)
            {
                direction = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
        //rotate com o navmesh
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyRigidbody.velocity;
            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(currentTarget.transform.position);
            enemyRigidbody.velocity = targetVelocity;
            transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);
        }

        
    }


            
    
}
}
