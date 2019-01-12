using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    Animator gunAnim;
    bool isFiring;
    //sound stuff
    private AudioSource gunSource;
    


	// Use this for initialization
	void Start () {
        isFiring = false;
        gunAnim = GetComponent<Animator>();
        gunSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))

        {
            isFiring = true;
            gunAnim.SetBool("isFiring", isFiring);
            if(gunSource.isPlaying == false)
            {
                gunSource.Play();
            }
            
        }
        else
        {
            isFiring = false;
            gunAnim.SetBool("isFiring", isFiring);
        }

    }
}
