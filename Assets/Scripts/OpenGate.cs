using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class OpenGate : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    public Key.KeyType GetKeyType(){
        return keyType;
    }

    public void OpenDoor(){
        anim.Play("BossDoorAnim");
    }
}
}