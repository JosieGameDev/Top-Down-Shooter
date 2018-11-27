using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    public GameObject player;
    public float speed = 5.0f;
    Transform transform;
    Transform currentPos;
    float distance;
    public float range;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        transform = player.transform;
        currentPos = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(currentPos.position, transform.position);

        if (player != null)
        {
            if (distance <= range)
            {
                currentPos.position = Vector3.MoveTowards(currentPos.position, transform.position, speed * 0.1f);
            }//
            
        }
	}

    //public void SetTarget(Transform newTarget)
    //{
    //    target = newTarget;
    //}

}
