using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DJD{

    [CreateAssetMenu(menuName ="Enemy/Enemy Actions/Enemy Attack ")]
public class EnemyAttackAction : EnemyAction 
{

    public int attackScore = 3;
    public float recoveryTime = 2; 
    public float maximumAttackAngle = 35; 
    public float minimumAttackAngle = -35;
    
    public float maximumDistanceNeededAttack = 3;
    public float minimumDistanceNeededAttack = 0;



 
 
 
 
 
 }
}
