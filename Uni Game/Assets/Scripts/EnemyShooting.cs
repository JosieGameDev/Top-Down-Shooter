using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform playerTransform;
    float distance;
    public int raange = 15;
    public float nextFire = 0;
    public float fireRate = 0.5f;

    //Vector2 speed = new Vector2(10f, 10f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get distance
        distance = Vector3.Distance(bulletSpawn.position, playerTransform.position);
        //check if in range
        if (distance < raange)
        {

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }

            //if(Input.GetKeyDown(KeyCode.Space))
            //{
            //    Fire();
            //}



        }


        //void Fire()
        //{
        //    //Instantiate(BulletObject);
        //    //Rigidbody2D bulletRigid = BulletObject.AddComponent<Rigidbody2D>();
        //    //bulletRigid.AddForce(bulletSpeed);

        //}




    }
    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}