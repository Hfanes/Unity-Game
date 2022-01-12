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

    
    private void Awake() {
        enemyMovement = GetComponent<EnemyMovement>();

    }

    private void Update() {
    }

    private void FixedUpdate() {
        HandleCurrentAction();
    }


    private void HandleCurrentAction(){
        if(enemyMovement.currentTarget == null)
        {
            enemyMovement.HandleDetection();
        }
        else
        {
            enemyMovement.HandleMoveToTarget();
        }
    }

    

    



 }
}
