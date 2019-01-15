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
    public AudioSource BigBoiDamageAS;
    public bool hasStartedCombat = false;
    HealthSystem1 bigBoyHealth;
    int health;
    int healthStg1 = 40;
    int healthStg2 = 20;

    bool mode1Active = true;
    bool mode2Active = true;
    bool mode3Active = true;

    int ActiveModes = 3;

    public AudioSource mode1DownAS;
    public AudioSource mode2DownAS;
    public AudioSource mode3DownAS;

    public AudioSource deathMonologueAS;
    public AudioSource deathExplosionAS;
    GameManager1 gameManager;
    AudioSource openingAS;  

    //more anim bools
    bool canSpawn = true;
    bool canShoot = true;
    bool canBomb = true;


    //mode1 vars
    public static Random r = new Random();
    public Transform randPos;
    public GameObject spawnPrefab;
    public GameObject spawnBadPrefab;
    bool hasPlayed = false;
    public AudioSource mode1AS;
    int maximumEnemies = 10;
    int currentEnemies;

    //mode 2 vars
    public GameObject bombPrefab;
    public AudioSource mode2AS;


    //mode 3 vars- laser vers
    
    Transform playerTransform;
    public float nextFire = 0;
    public float fireRate = 0.1f;
    public AudioSource cannonShootAS;
    

    //mode 3 vars - cannon vers
    public GameObject cannonBallPrefab;
    public Transform cannonSpawnPt;

    public AudioSource mode3AS;
    

    // Use this for initialization
    void Start () {
        
        player = GameObject.FindWithTag("Player");
        currentMethod = "shootCannon";
        //StartCoroutine("BossFunction");
        //laserLine = GameObject.FindGameObjectWithTag("laser");
        bigBoyHealth = GetComponent<HealthSystem1>();
        health = bigBoyHealth.health;
        gameManager = GetComponent<GameManager1>();
        openingAS = GameObject.FindWithTag("openAS").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        

        if (health> 0)
        {

            

            //start attack if it hasnt already
            if (hasStartedCombat == false)
            {
                if (player.transform.position.x > 8)
                {
                    StartCoroutine("BossFunction");
                    hasStartedCombat = true;
                }
            }
            //change which mdoe its on at diff time intevals
            if (Time.time > nextModeChange)
            {
                nextModeChange = Time.time + modeChangeRate;
                modeSwitcher();

                //Debug.Log(currentMethod);
            }
            setAnimBools();

            if (hasStartedCombat == true)
            {
                //get current health and remove mode if need be 
                health = bigBoyHealth.health;
                removeModes();

                //set  aniamtor
                if (currentMethod == "spawnBaddies")
                {
                    bigBossAnimator.SetBool("isSpawn", true);
                    bigBossAnimator.SetBool("isShoot", false);
                    bigBossAnimator.SetBool("isBombing", false);
                    bigBossAnimator.SetBool("RECHECK", true);

                    Invoke("resetRecheckAnimBool", .01f);
                }
                if (currentMethod == "shootCannon")
                {
                    bigBossAnimator.SetBool("isSpawn", false);
                    bigBossAnimator.SetBool("isShoot", true);
                    bigBossAnimator.SetBool("isBombing", false);
                    bigBossAnimator.SetBool("RECHECK", true);

                    Invoke("resetRecheckAnimBool", .01f);
                }
                if (currentMethod == "releaseBombs")
                {
                    bigBossAnimator.SetBool("isSpawn", false);
                    bigBossAnimator.SetBool("isShoot", false);
                    bigBossAnimator.SetBool("isBombing", true);
                    bigBossAnimator.SetBool("RECHECK", true);

                    Invoke("resetRecheckAnimBool", .01f);
                }

                
                
            }
        }
        else if (health <=0)
        {
            bigBossAnimator.SetBool("IsDying", true);
            StopAllCoroutines();
            if (deathMonologueAS.isPlaying == false)
            {
                deathMonologueAS.Play();
            }
            Invoke("destroyBossImage", 7f);

        }

        
    }


    private void destroyBossImage()
    {
        bigBossAnimator.SetBool("isExploding", true);
        deathExplosionAS.Play();
        Invoke("turnOffBossSprite", 5f);
        
    }

    private void turnOffBossSprite()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Invoke("loadWin", 1f);
    }
    private void loadWin()
    {
        gameManager.LoadWin();
    }

    private void resetRecheckAnimBool()
    {
        
        bigBossAnimator.SetBool("RECHECK", false);
    }

    public IEnumerator BossFunction()
    {
        while (true)
        {
            
                if (currentMethod != "shootCannon")
                {
                    Invoke(currentMethod, 0);
                    yield return new WaitForSeconds(2f);
                }
                else if (currentMethod == "shootCannon")
                {
                    Invoke(currentMethod, 0);
                    yield return new WaitForSeconds(0.5f);

                }
            
        }
    }

    //delete modes as health decreases
    public void removeModes()
    {
        if (health < healthStg1 && ActiveModes == 3)
        {
            //bigBossAnimator.SetBool("RECHECK", true);

            //Invoke("resetRecheckAnimBool", .01f);

            Debug.Log(currentMethod);

            if (currentMethod == "spawnBaddies")
            {
                //set this mode to inactive
                mode1Active = false;
                mode1DownAS.Play();
                canSpawn = false;
            }
            else if (currentMethod == "shootCannon")
            {
                mode2Active = false;
                mode2DownAS.Play();
                canShoot = false;
            }
            else if (currentMethod == "releaseBombs")
            {
                mode3Active = false;
                mode3DownAS.Play();
                canBomb = false;
            }

            ActiveModes = 2;
            
        }
        else if (health < healthStg2 && ActiveModes == 2)
        {
            if (currentMethod == "spawnBaddies")
            {
                //set this mode to inactive
                mode1Active = false;
                mode1DownAS.Play();
                canSpawn = false;
            }
            else if (currentMethod == "shootCannon")
            {
                mode2Active = false;
                mode2DownAS.Play();
                canShoot = false;
            }
            else if (currentMethod == "releaseBombs")
            {
                mode3Active = false;
                mode3DownAS.Play();
                canBomb = false;
            }

            ActiveModes = 1;
        }

        //FDebug.Log(ActiveModes);
    }

    private void setAnimBools()
    {
        bigBossAnimator.SetBool("canShoot", canShoot);
        bigBossAnimator.SetBool("canSpawn", canSpawn);
        bigBossAnimator.SetBool("canBomb", canBomb);
        //bigBossAnimator.SetBool("RECHECK", true);

        //Invoke("resetRecheckAnimBool", .5f);
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
            if(mode2Active == true)
            {
                currentMethod = "shootCannon";
                if(openingAS.isPlaying == false)
                {
                    mode2AS.Play();
                }
                
            }
            else if (mode3Active ==true)
            {
                currentMethod = "releaseBombs";
                if (openingAS.isPlaying == false)
                {
                    mode3AS.Play();
                }
                
            }
            
        }
        else if(currentMethod == "shootCannon")
        {
            if (mode3Active == true)
            {
                currentMethod = "releaseBombs";
                
                if (openingAS.isPlaying == false)
                {
                    mode3AS.Play();
                }
            }
            else if (mode1Active ==true)
            {
                currentMethod = "spawnBaddies";
                if (openingAS.isPlaying == false)
                {
                    mode1AS.Play();
                }
               
            }
        }
        else if(currentMethod == "releaseBombs")
        {
            if (mode1Active == true)
            {
                currentMethod = "spawnBaddies";
                if (openingAS.isPlaying == false)
                {
                    mode1AS.Play();
                }
                
            }
            else if (mode2Active == true)
            {
                currentMethod = "shootCannon";
                if (openingAS.isPlaying == false)
                {
                    mode2AS.Play();
                }
                
            }
        }
        else
        {
            //Debug.Log("didnt change mode");
        }
    }


    private void spawnBaddies()
    {
        // for mode 1 create small enemies around the arena
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //if theres not too many in scene already
        if (currentEnemies <= maximumEnemies)
        {

            //get a random location within the big boss map
            Transform spawn1 = randomSpawnPt();

            //create spawn anim here
            Instantiate(spawnPrefab, spawn1.position, spawn1.rotation);
        }
        else
        {
            //Debug.Log("too many in scene");
        }
        
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

    //FAILED LASER SYSTEM USING RAYCASTING

    //private void shootLaser()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(laserSpawn.transform.position, laserSpawn.transform.TransformDirection(Vector2.up));
    //    laserLine.GetComponent<LineRenderer>().SetPosition(0, laserSpawn.transform.position);
    //    LineRenderer line = laserLine.GetComponent<LineRenderer>();

    //    if (hit.collider != null)
    //    {

    //        //add pts to the array
    //        laserLinePts[0] = laserSpawn.transform.position;
    //        laserLinePts[1] = hit.transform.position;

    //        //set up the line renderer 
            
    //        laserLine.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            

    //        Debug.Log("is hitting");
          
    //    }
    //    else
    //    {
    //        laserLine.GetComponent<LineRenderer>().SetPosition(0, laserSpawn.transform.position);
    //        laserLine.GetComponent<LineRenderer>().SetPosition(1, hit.point);

    //    }


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

    //}

    //BIG BOY BULLET MODE AS A REPLACEMENT FOR LASER

    private void shootCannon()
    {
        Instantiate(cannonBallPrefab, cannonSpawnPt.position, cannonSpawnPt.rotation);
        cannonShootAS.Play();
    }


    private void Fire()
    {
        //Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);
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
