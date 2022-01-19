using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class DamagePlayer : MonoBehaviour
{

    public int damage = 35;

    private void OnTriggerEnter(Collider other) {
        {
            Debug.Log("Sofre Dano");
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if(playerStats != null){
                playerStats.TakeDamage(damage);
            }
        }
    }

 }
}
