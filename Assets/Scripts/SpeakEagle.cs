using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakEagle : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    public Text text;
    public int nivel;


    void Start()
    {
        text.gameObject.SetActive(false);
        if(nivel == 1)
        {
            text.text = "Procure as chaves e abra as portas";
        }
        if (nivel == 2)
        {
            text.text = "Siga os caminhos e encontre um baú com uma nova arma" + Environment.NewLine +
                "Cuidado pelo caminho, pode encontrar inimigos. ";
        }
        if (nivel == 3)
        {
            text.text = "Derrote os inimigos, apanhe a nova arma do bau e avance para a sala final!!";
        }
        if (nivel == 4)
        {
            text.text = "Encontre a chave que irá abrir a porta final!";
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Player.name)
        {

            text.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Player.name)
        {

            text.gameObject.SetActive(false);

        }
    }




}
