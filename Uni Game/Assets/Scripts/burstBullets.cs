using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstBullets : MonoBehaviour {

    public Transform spwn1;
    public Transform spwn2;
    public Transform spwn3;
    public float nextFire = 0;
    public float fireRate = 0.5f;
    //public GameObject player;

    public GameObject enemyBullet;

	// Use this for initialization
	void Start ()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
            //gunAnim.SetBool("EnemyShooting", true);
        }
        else
        {
            //gunAnim.SetBool("EnemyShooting", false);
        }
    }

    void Fire()
    {
        Instantiate(enemyBullet, spwn1.position, spwn1.rotation);
        Instantiate(enemyBullet, spwn2.position, spwn2.rotation);
        Instantiate(enemyBullet, spwn3.position, spwn3.rotation);

    }
}
