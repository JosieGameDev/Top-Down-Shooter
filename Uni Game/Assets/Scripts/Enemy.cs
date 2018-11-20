using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class EnemySpawnedEvent : UnityEvent<Transform> { }

public class Enemy : MonoBehaviour {

    public EnemySpawnedEvent onSpawn;
    //public Rigidbody2D Robot;
    public SpriteRenderer RobotSprite;
    public GameObject player;
    public GameObject robot;
    

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);
        RobotSprite.flipX = false;
	}
	
	// Update is called once per frame
	void Update () {
        //flip enemy based on direction of travel


        if (player.transform.position.x < robot.transform.position.x)
        {
            RobotSprite.flipX = true;
        }
        else if (player.transform.position.x >= robot.transform.position.x)
        {
            RobotSprite.flipX = false;
        }

        //

        Debug.Log(robot.transform.position.x);
        Debug.Log(player.transform.position.x);
        //Debug.Log(Robot.velocity);


        //if (Robot.velocity.x < 0)
        //{
        //    RobotSprite.flipX = true;
        //}
        //else 
        //{
        //    RobotSprite.flipX = false;
        //}

    }
}
