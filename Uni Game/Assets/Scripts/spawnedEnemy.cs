using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedEnemy : MonoBehaviour {

    //vars 
    public GameObject enemyPrefab;
    public AudioSource warpInAC;

	// Use this for initialization
	void Start () {
        Invoke("createEnemy", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void createEnemy()
    {
        if(warpInAC.isPlaying == false)
        {
            warpInAC.Play();
        }
        Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
