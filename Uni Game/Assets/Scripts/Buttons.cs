using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    Image buttonNormal;
    public float scaleSize = 1.5f;
	// Use this for initialization
	void Start () {
        buttonNormal = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        buttonNormal.transform.localScale = (buttonNormal.transform.localScale * scaleSize);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");

        buttonNormal.transform.localScale = (buttonNormal.transform.localScale / scaleSize);
    }
}
