using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour {

    public AudioSource playerDeadAC;
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
        StartCoroutine("openGameOver");
        if (playerDeadAC.isPlaying == false)
        {
            playerDeadAC.Play();
        }
           
    }
    public IEnumerator openGameOver()
    {
        Debug.Log("running enum");
        yield return new WaitForSeconds(1f); 
       
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
    public void LoadLv2()
    {
        SceneManager.LoadScene("Level Two");
    }
    public void LoadLvl3()
    {
        SceneManager.LoadScene("Level Three");
    }
    public void LoadBoss()
    {
        SceneManager.LoadScene("Boss Level");
    }
    public void LoadWin()
    {
        SceneManager.LoadScene("Win Screen");
    }


}
