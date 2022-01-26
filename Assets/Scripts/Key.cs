using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD
{
public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public string itemName;

    public Sprite SilverIcon;
    public Sprite GoldIcon;


    public enum KeyType{
        Silver,
        Gold
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
 }   
}
