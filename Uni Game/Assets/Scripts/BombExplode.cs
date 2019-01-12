using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour {

    //damage stuff
    GameObject explosionHurtTrigger;
    public int damage = 2;
    public float timeCountdown = 2.1f;
    GameObject bomb;

    //animation stuff
    public Animator bombAnimator;

    //sound
    public AudioSource bombCountdown;
    public AudioSource bombExplosion;
    
	// Use this for initialization
	void Start () {
        
        bomb = GameObject.FindGameObjectWithTag("bomb");
        bomb.GetComponent<Collider2D>().enabled = false;

        if(bombCountdown.isPlaying == false)
        {
            bombCountdown.Play();
        }
        //invoke explosion after time f 
        Invoke("explodeBomb", timeCountdown);
        //destroy bomb after this

        Invoke("destroyBomb", 4f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void explodeBomb()
    {
        Debug.Log("playing ex method");
        bomb.GetComponent<Collider2D>().enabled = true;
        bombAnimator.SetBool("isExploding", true);
        if(bombExplosion.isPlaying ==false)
        {
            bombExplosion.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            explosionHurtTrigger.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void destroyBomb()
    {
        Debug.Log("playing destroy method");
        //destroy the bomb
        GameObject.Destroy(GameObject.FindGameObjectWithTag("bomb"));
    }

}
