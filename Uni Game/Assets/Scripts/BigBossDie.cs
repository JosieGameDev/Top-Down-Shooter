using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossDie : MonoBehaviour {

    public AudioSource deathTalkingAS;
    public AudioSource damageSoundAS;

	// Use this for initialization
	void Start () {
        damageSoundAS.Play();
        Invoke("playWords", 1f);
	}

     public void Die()
    {
        damageSoundAS.Play();
        Invoke("playWords", 1f);
    }
	
    private void playWords()
    {
        deathTalkingAS.Play();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
