using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrailDop : MonoBehaviour {



    //vars
    public float nextDrop = 0f;
    public float dropRate = 0.5f;

    public GameObject hurtTrail;
    public Transform damageSpwnPt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(Time.time > nextDrop);
		if (Time.time > nextDrop)
        {
            nextDrop = Time.time + dropRate;
            Drop();
            
        }
        else
        {
            Debug.Log("not happening ");
        }
        
	}

    void Drop()
    {
        print("dropping...");
        Instantiate(hurtTrail, damageSpwnPt.position, damageSpwnPt.rotation);
    }
}
