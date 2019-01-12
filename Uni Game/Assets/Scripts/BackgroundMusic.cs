using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    private AudioSource BGmusicAC;

	// Use this for initialization
	void Start () {
        BGmusicAC = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//play all the time
        if(BGmusicAC.isPlaying ==false)
        {
            BGmusicAC.Play();
        }
	}
}
