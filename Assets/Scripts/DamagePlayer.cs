using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class DamagePlayer : MonoBehaviour
{

    public int damage = 25;
    private void OnTriggerEInter(Collider other) {
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if(playerStats != null){
                playerStats.TakeDamage(damage);
            }
        }
    }

 }
}
