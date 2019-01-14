﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem1 : MonoBehaviour {

    public int health = 6;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;
    public Image hearts6;
    public Image hearts5;
    public Image hearts4;
    public Image hearts3;
    public Image hearts2;
    public Image hearts1;
    public bool isPlayer = false;
    public bool playerIsResistant = false;
    public bool isBigBoss;

    //public bool hurtAnim = false;

    public float playerBuffTime = 0.5f;
    public Animator playerAnim;

    //damage sound
    public AudioSource enemyHurtAC;
    public AudioSource playerHurtAC;




    public void TakeDamage (int damage)
    {
        //health -= damage;

        if (isPlayer == true && playerIsResistant != true)
        {
            onDamaged.Invoke(health);
            playerIsResistant = true;
            Invoke("resentResiliant", playerBuffTime);
            health -= damage;
            playerHurtAC.Play();



            //set up the anim
            //hurtAnim = true;
            playerAnim.SetBool("hurtAnim", true);
            Invoke("disabaleHurtAnim", 1f);
            

        }
        else if (isPlayer != true)
        {
            onDamaged.Invoke(health);
            health -= damage;
            if(enemyHurtAC.isPlaying == false)
            {
                enemyHurtAC.Play();
            }

            
        }
        


        //disable circle collider
        //GetComponent<CircleCollider2D>().enabled = false;
        //Invoke("enableCollider", 3);

        if (isPlayer == true)
        {
            //changing hearts visible based on health
            if (health <= 5)
            {
                hearts6.enabled = false;
            }
            else
            {
                hearts6.enabled = true;
            }

            if (health <= 4)
            {
                hearts5.enabled = false;
            }
            else
            {
                hearts5.enabled = true;
            }

            if (health <= 3)
            {
                hearts4.enabled = false;
            }
            else
            {
                hearts4.enabled = true;
            }

            if (health <= 2)
            {
                hearts3.enabled = false;
            }
            else
            {
                hearts2.enabled = true;
            }

            if (health <= 1)
            {
                hearts2.enabled = false;
            }
            else
            {
                hearts2.enabled = true;
            }

        }

        if (health < 1)
        {
            Destroy(hearts1);
            onDie.Invoke();
        }
    }

    private void disabaleHurtAnim()
    {
        //set the hurt anim false 
        
        playerAnim.SetBool("hurtAnim", false);
    }

    void enableCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void resentResiliant()
    {
        playerIsResistant = false;
    }
}
