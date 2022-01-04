using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJD{


public class Interactable : MonoBehaviour
{

    public float radius = 0.6f;
    public string interacatbleText;

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);    
    }

    public virtual void Interact(PlayerManager playerManager) //virtual void que usa este método pode ser override e alterar, para varias ações
    {
        Debug.Log("Interagiste com um objeto");
    }





 }
}
