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
    Vector3 faceLeft = new Vector3(-0.318f, -0.18f);
    Vector3 faceRight = new Vector3(0.318f, -0.18f);
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

        //run code to flip the gun if needed
        FlipGunAnim();

	}

    void FlipGunAnim()


    {

        //get srpite of gun 
        spriteGun = GetComponent<SpriteRenderer>();

        //make new transforms for flip

        
        
        //check rotation 
        if ((gun.transform.eulerAngles.z <= 270 && gun.transform.eulerAngles.z >= 90))
        {
            //flip image in these conditions
            spriteGun.flipY = true;
            //spritePlayer.flipX = true;
            gun.transform.localPosition = faceLeft;


        }
        else
        {
            spriteGun.flipY = false;
            //spritePlayer.flipX = false;
            gun.transform.localPosition = faceRight;

        }

        //flip player based on whether gun is flipped
        if (spriteGun.flipY == true)
        {
            spritePlayer.flipX = true;
        }
        else
        {
            spritePlayer.flipX = false;
        }

                
    }
}
