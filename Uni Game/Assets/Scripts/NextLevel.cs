using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MyIntEvent : UnityEvent<int> { }


public class NextLevel : MonoBehaviour {

    public UnityEvent OnEnter;

    

    void OnTriggerEnter2D(Collider2D other)
    {

       

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("its colliding");
            OnEnter.Invoke();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
