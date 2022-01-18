using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DJD{
public class CharacterBlockCollision : MonoBehaviour
{
    public CapsuleCollider characterCollider;
    public CapsuleCollider characterBlockerCollider;

    void Start()
    {
        Physics.IgnoreCollision(characterCollider, characterBlockerCollider, true);
    }

 }
}
