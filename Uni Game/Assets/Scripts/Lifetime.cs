using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour {

    //public float lifetime = 2f;
    //public float nextDestroy = 5f;
    public float timer;
    public float lifetime = 2;
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer += 1.0f * Time.deltaTime;
		
        if (timer >= lifetime)
        {
            GameObject.Destroy(gameObject);
        }

	}

    public void DestroyHurt()
    {
        Destroy(gameObject);
    }

}
