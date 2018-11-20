﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Animator gunAnim;


	// Use this for initialization
	void Start () {
        gunAnim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButton(0))
        {
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }

	}

    public void onDie()
    {
        SceneManager.LoadScene("Zombie Shooter Level 1", LoadSceneMode.Additive);
    }

    
}
