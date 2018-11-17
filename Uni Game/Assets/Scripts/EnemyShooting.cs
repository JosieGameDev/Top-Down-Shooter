using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    //Vector2 speed = new Vector2(10f, 10f);

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
{
            Fire();
        }



    }

    //void Fire()
    //{
    //    //Instantiate(BulletObject);
    //    //Rigidbody2D bulletRigid = BulletObject.AddComponent<Rigidbody2D>();
    //    //bulletRigid.AddForce(bulletSpeed);
        
    //}

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
