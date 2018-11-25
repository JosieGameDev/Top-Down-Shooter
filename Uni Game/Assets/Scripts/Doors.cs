using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject door;
    Collider2D collider;
    //Animator animator;
    bool doorOpening;


    // Use this for initialization
    void Start () {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;
        //animator = GetComponent<Animator>();
        doorOpening = false;

	}
	
	// Update is called once per frame
	void Update () {
        disableDoors();
	}

    void disableDoors()
    {
        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null
            && enemy5 == null && enemy6 == null)
        {
            collider.enabled = false;
            doorOpening = true;
            //animator.SetBool("doorOpening", doorOpening);
            
        }
            

    }
}
