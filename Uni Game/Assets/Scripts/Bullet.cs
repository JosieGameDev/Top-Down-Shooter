using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed = 100.0f;
    public int damage = 1;
    public bool enemy;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player" && enemy)
        {
            other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
        else if (other.transform.tag == "Enemy" && !enemy)
        {
            other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
        

    }

    private void OnBecameInvisible()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
