using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedEnemy : MonoBehaviour {

    //vars 
    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
        Invoke("createEnemy", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void createEnemy()
    {
        Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
