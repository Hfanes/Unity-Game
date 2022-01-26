using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private int nextScene;
    private void Start() {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(nextScene);
        } 
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(nextScene);
        } 
    }
}
