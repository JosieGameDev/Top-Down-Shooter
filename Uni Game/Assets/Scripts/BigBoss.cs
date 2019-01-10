using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour {

    //vars 
    GameObject player;

    //mode1 vars
    public static Random r = new Random();
    public Transform randPos;
    public GameObject spawnPrefab;
    public GameObject spawnBadPrefab;
    bool hasPlayed = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
        
		if(player.transform.position.x > this.transform.position.x && hasPlayed == false)
        {
            spawnBaddies();
            spawnBaddies();
            spawnBaddies();
            spawnBaddies();
            spawnBaddies();
            hasPlayed = true;
        }
	}

    private void spawnBaddies()
    {
        // for mode 1 create small enemies around the arena

        //get a random location within the big boss map
        Transform spawn1 = randomSpawnPt();
    
        //create spawn anim here
        Instantiate(spawnPrefab, spawn1.position, spawn1.rotation);

        
       


    }

    private void changeToBaddies(GameObject spawnAnim)
    {

        Instantiate(spawnBadPrefab, spawnAnim.transform);
        Destroy(spawnAnim);
    }

    private void releaseBombs()
    {
        // for mode 2 throw bombs which explode after a small delay

        //get a random location within the big boss map
        Transform spawn1 = randomSpawnPt();

        //create a bomb here

    }

    private void shootLaser()
    {
        //for mode 3 shoot a big ol laser across the arena 
    }


    private Transform randomSpawnPt()
    {
        //corners of the spawn canvas(area near player)
        float x1, x2, y1, y2;

        //assign values from the gameobjects
        x1 = GameObject.FindGameObjectWithTag("topL").transform.position.x;
        y1 = GameObject.FindGameObjectWithTag("topL").transform.position.y;
        x2 = GameObject.FindGameObjectWithTag("butR").transform.position.x;
        y2 = GameObject.FindGameObjectWithTag("butR").transform.position.y;

        //the randoms 
        float randX, randY;

        //create a random x value
        randX = Random.Range(x1, x2);
        randY = Random.Range(y1, y2);

        //remake if its within the blocks


        //the position
        randPos.position = new Vector3(randX, randY, 0);

        return randPos;

    }

    
}
