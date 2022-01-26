using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour{

    float timer;
    public float deathtimer = 1;
    public GameObject OnDestroyFuncTarget;
    public string OnDestroyFuncMessage;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= deathtimer)
        {
            if (OnDestroyFuncTarget != null)
                OnDestroyFuncTarget.SendMessage(OnDestroyFuncMessage);
            Destroy(gameObject);
        }
	
	}
}
