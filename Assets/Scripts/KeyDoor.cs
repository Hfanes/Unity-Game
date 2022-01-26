using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    Animator anim;

        private AudioSource _soundDoor;
        private void Awake() {
        anim = GetComponent<Animator>();
            _soundDoor = GetComponent<AudioSource>();
        }
    public Key.KeyType GetKeyType(){
        return keyType;
    }

    public void OpenDoor(){
        anim.Play("Lvl1DoorSilver");
            _soundDoor.Play();
        }





 }
}
