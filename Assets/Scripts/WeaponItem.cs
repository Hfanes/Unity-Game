using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJD
{


    [CreateAssetMenu(menuName ="Items/Weapon Item")]

    public class WeaponItem: Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("One Handed Attack Animations")]
        public string OH_Light_Attack_1;
        public string OH_Heavy_Attack_1;

        [Header ("Damage")]
        public int lightDamage = 25;
        public int heavyDamage = 35;



        [Header ("Stamina")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;




    }





}

