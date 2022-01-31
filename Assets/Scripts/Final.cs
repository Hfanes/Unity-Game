using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DJD{
public class Final : MonoBehaviour
{
    EnemyStats enemyStats;
    public GameObject book;
    private void Awake() {
        enemyStats = GetComponent<EnemyStats>();
    }

    private void Update() {
        ShowBook();
    }


    public void ShowBook(){
        if(enemyStats.isDead == true)
        {
            book.SetActive(true);
        }
    }
 }
}
