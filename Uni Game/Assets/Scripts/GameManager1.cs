using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void endGame()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
