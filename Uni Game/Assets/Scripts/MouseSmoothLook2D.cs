using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSmoothLook2D : MonoBehaviour {

    public Camera theCamera;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;
    public GameObject gun;
    SpriteRenderer spriteGun;
    public SpriteRenderer spritePlayer;

    public GameObject bulletSpawnPoint;
    //Vector3 gunFaceLeft;
    //Vector3 gunFaceRight;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;

        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);

        //code to flip x pos of the gun and arm 
        //gunFaceLeft = new Vector3(-0.12f, 0, 0);
        //gunFaceRight = new Vector3(0.12f, 0, 0);

        //run code to flip the gun if needed
        FlipGunAnim();

	}

    void FlipGunAnim()


    {

        //get srpite of gun 
        spriteGun = GetComponent<SpriteRenderer>();

        //check rotation 
        if ((gun.transform.eulerAngles.z < 270 && gun.transform.eulerAngles.z > 90))
        {
            //flip image in these conditions
            spriteGun.flipY = true;
            spritePlayer.flipX = true;
            spriteGun.transform.localPosition = new Vector3(0f, 0f, 0);
            bulletSpawnPoint.transform.localPosition = new Vector3(0.4f, -0.1f, 0);
        }
        else
        {
            spriteGun.flipY = false;
            spritePlayer.flipX = false;
            spriteGun.transform.localPosition = new Vector3(0f, -0f, 0);
            bulletSpawnPoint.transform.localPosition = new Vector3(0.4f, 0.1f, 0);
        }
    }
}
