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
        pauseWithEsc();
	}

    public void pauseWithEsc()
    {
        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level One");
    }

    public void endGame()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void EndTutorial()
    {
        SceneManager.LoadScene("Tutorial endScreen");
    }


}
