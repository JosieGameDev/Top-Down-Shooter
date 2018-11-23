using System.Collections;
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





    public void TakeDamage (int damage)
    {
        health -= damage;

        onDamaged.Invoke(health);

        
        //changing hearts visible based on health
        if (health == 5)
        {
            Destroy(hearts6);
        }
        else if (health == 4)
        {
            Destroy(hearts5);
        }
        else if (health == 3)
        {
            Destroy(hearts4);
        }
        else if (health == 2)
        {
            Destroy(hearts3);
        }
        else if (health == 1)
        {
            Destroy(hearts2);
        }

        

        if (health < 1)
        {
            Destroy(hearts1);
            onDie.Invoke();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
