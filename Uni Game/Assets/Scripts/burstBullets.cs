using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstBullets : MonoBehaviour {

    public Transform spwn1;
    public Transform spwn2;
    public Transform spwn3;
    public Transform spwn4;
    public Transform spwn5;
    public Transform spwn6;
    public Transform spwn7;
    public Transform spwn8;
    public Transform spwn9;
    public Transform spwn10;
    public Transform spwn11;
    public Transform spwn12;
    public Transform spwn13;
    public Transform spwn14;
    public Transform spwn15;
    public Transform spwn16;

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
        Instantiate(enemyBullet, spwn4.position, spwn4.rotation);
        Instantiate(enemyBullet, spwn5.position, spwn5.rotation);
        Instantiate(enemyBullet, spwn6.position, spwn6.rotation);
        Instantiate(enemyBullet, spwn7.position, spwn7.rotation);
        Instantiate(enemyBullet, spwn8.position, spwn8.rotation);
        Instantiate(enemyBullet, spwn9.position, spwn9.rotation);
        Instantiate(enemyBullet, spwn10.position, spwn10.rotation);
        Instantiate(enemyBullet, spwn11.position, spwn11.rotation);
        Instantiate(enemyBullet, spwn12.position, spwn12.rotation);
        Instantiate(enemyBullet, spwn13.position, spwn13.rotation);
        Instantiate(enemyBullet, spwn14.position, spwn14.rotation);
        Instantiate(enemyBullet, spwn15.position, spwn15.rotation);
        Instantiate(enemyBullet, spwn16.position, spwn16.rotation);
    }
}
