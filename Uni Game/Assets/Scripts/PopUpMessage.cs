using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMessage : MonoBehaviour {

    [SerializeField]
    Canvas messageCanvas;

	// Use this for initialization
	void Start () {
        messageCanvas.enabled = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Debug.Log("Registering collision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Registering collision");
            TurnOnMessage();
        }
    }

    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        TurnOffMessage();
    //        Debug.Log("Registers leaving ");
    //    }
        
    //}

    public void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }

    public void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
