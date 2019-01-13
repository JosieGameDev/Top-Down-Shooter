using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour {

    //vars 
    GameObject player;
    public float modeSwitchTime = 10f;
    string currentMethod;
    public Animator bigBossAnimator;
    public float nextModeChange = 0;
    public float modeChangeRate = 5;
    public AudioSource bigBoiModeChangeAC;

    //mode1 vars
    public static Random r = new Random();
    public Transform randPos;
    public GameObject spawnPrefab;
    public GameObject spawnBadPrefab;
    bool hasPlayed = false;

    //mode 2 vars
    public GameObject bombPrefab;


    //mode 3 vars
    public GameObject laserPrefab;
    public Transform laserSpawn;
    Transform playerTransform;
    public float nextFire = 0;
    public float fireRate = 0.1f;
    GameObject laserLine;
    Vector3[] laserLinePts = new Vector3[2];
    

    // Use this for initialization
    void Start () {
        
        player = GameObject.FindWithTag("Player");
        currentMethod = "shootLaser";
        StartCoroutine("BossFunction");
        laserLine = GameObject.FindGameObjectWithTag("laser");
        
	}
	
	// Update is called once per frame
	void Update () {

        //invoke current mode 
        //Invoke(currentMethod, 2f);

        //set  aniamtor
        if (currentMethod == "spawnBaddies")
        {
            bigBossAnimator.SetBool("isSpawn", true);
            bigBossAnimator.SetBool("isShoot", false);
            bigBossAnimator.SetBool("isBombing", false);
        }
        if (currentMethod == "shootLaser")
        {
            bigBossAnimator.SetBool("isSpawn", false);
            bigBossAnimator.SetBool("isShoot", true);
            bigBossAnimator.SetBool("isBombing", false);
        }
        if (currentMethod == "releaseBombs")
        {
            bigBossAnimator.SetBool("isSpawn", false);
            bigBossAnimator.SetBool("isShoot", false);
            bigBossAnimator.SetBool("isBombing", true);
        }

        //change which mdoe its on at diff time intevals
        if(Time.time > nextModeChange)
        {
            nextModeChange = Time.time + modeChangeRate;
            modeSwitcher();
            
            Debug.Log(currentMethod);
        }


        
    }

    public IEnumerator BossFunction()
    {
        while (true)
        {
            
                if (currentMethod != "shootLaser")
                {
                    Invoke(currentMethod, 0);
                    yield return new WaitForSeconds(1f);
                }
                else if (currentMethod == "shootLaser")
                {
                    Invoke(currentMethod, 0);
                    yield return new WaitForSeconds(0.01f);

                }
            
        }
    }

    private void modeSwitcher()
    {
        //when called it switches to next mode in sequence 
        //play sound 
        if(bigBoiModeChangeAC.isPlaying == false)
        {
            bigBoiModeChangeAC.Play();
        }

        if (currentMethod == "spawnBaddies")
        {
            currentMethod = "shootLaser";
        }
        else if(currentMethod == "shootLaser")
        {
            currentMethod = "releaseBombs";
        }
        else if(currentMethod == "releaseBombs")
        {
            currentMethod = "spawnBaddies";
        }
        else
        {
            Debug.Log("didnt change mode");
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
        Instantiate(bombPrefab, spawn1.position, spawn1.rotation);
    }

    private void shootLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserSpawn.transform.position, laserSpawn.transform.TransformDirection(Vector2.up));
        laserLine.GetComponent<LineRenderer>().SetPosition(0, laserSpawn.transform.position);
        LineRenderer line = laserLine.GetComponent<LineRenderer>();

        if (hit.collider != null)
        {

            //add pts to the array
            laserLinePts[0] = laserSpawn.transform.position;
            laserLinePts[1] = hit.transform.position;

            //set up the line renderer 
            
            laserLine.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            

            Debug.Log("is hitting");
          
        }
        else
        {
            laserLine.GetComponent<LineRenderer>().SetPosition(0, laserSpawn.transform.position);
            laserLine.GetComponent<LineRenderer>().SetPosition(1, hit.point);

        }


        //RaycastHit2D hit;
        //if(Physics2D.Raycast(laserSpawn.transform.position, laserSpawn.transform.TransformDirection(Vector2.up), )
        //{
        //    Debug.DrawRay(laserSpawn.transform.position, laserSpawn.transform.TransformDirection(Vector2.up) * hit.distance, Color.yellow);
        //    Debug.Log("Did Hit");

        //    //set up the line renderer 
        //    laserLine.GetComponent<LineRenderer>().SetPosition(1, laserSpawn.transform.position);
        //    laserLine.GetComponent<LineRenderer>().SetPosition(2, hit.transform.position);


        //}
        //else
        //{
        //    Debug.DrawRay(laserSpawn.transform.position, laserSpawn.transform.TransformDirection(Vector2.up) * 1000, Color.white);
        //    Debug.Log("Did not Hit");


        //}




        //Debug.Log("running");

        //Fire();

    }

    private void Fire()
    {
        Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);
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
