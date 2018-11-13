using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyEnemyTest : MonoBehaviour {

    public Transform player;
    public float nodeDis;
    public float upDownDis;
    public float speed;

    public Transform target;
    private Vector2[] nodeArray = new Vector2[3];
	// Use this for initialization
	void Start ()
    {
        CreateNodes();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, target.position, speed * 0.1f);

        if (Vector2.Distance(player.position, gameObject.transform.position) <= 3)
        {
            CreateNodes();
        }
	}

    void CreateNodes()
    {
        nodeArray[0] = new Vector2(player.position.x - nodeDis, player.position.y);
        nodeArray[1] = new Vector2(player.position.x - nodeDis, player.position.y + upDownDis);
        nodeArray[2] = new Vector2(player.position.x - nodeDis, player.position.y - upDownDis);

        int randIndex = Random.Range(0, 3);

        target.position = nodeArray[randIndex];
    }
}
