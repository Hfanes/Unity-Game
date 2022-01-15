using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class EnemyAnimatorManager : AnimatorManager
{
    EnemyMovement enemyMovement;
    private void Awake() {
        anim = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnAnimatorMove() {
    }






 }
}


