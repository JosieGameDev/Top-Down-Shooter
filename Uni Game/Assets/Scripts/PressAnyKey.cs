using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {

    public GameManager1 gameManager;
    public AudioSource openingSoundAS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey)
        {
            if(openingSoundAS.isPlaying == false)
            {
                openingSoundAS.Play();
            }

            Invoke("openMenu", 1f);
        }
	}

    void openMenu()
    {
        gameManager.BackToMainMenu();
    }
}
