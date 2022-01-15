using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class EnemyDamage : MonoBehaviour
{

    public GameObject enemySword;

    
    public void enemyOpenDamageCollider(){
        enemySword.GetComponentInChildren<Collider>().enabled = true;
    }

    public void enemyCloseDamageCollider(){
        enemySword.GetComponentInChildren<Collider>().enabled = false;
        
    }
    


 }
}
