using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour {

    public float time = 1;
    public bool repeat = false;
    public UnityEvent onTimerComplete;


	// Use this for initialization
	void Start () {
		if(repeat)
        {
            InvokeRepeating("OnTimerComplete", 0, time);
        }
        else
        {
            Invoke("OnTimerComplete", time);
        }
	}
	
    private void OnTimerComplete()
    {
        onTimerComplete.Invoke();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
