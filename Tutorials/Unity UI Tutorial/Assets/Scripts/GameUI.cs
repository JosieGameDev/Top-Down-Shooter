using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public Slider healthSlider;
    public IntVariable health;

    public Text scoreText;
    public IntVariable score;
    


    private void Start()
    {
        healthSlider.value = healthSlider.maxValue;
        scoreText.text = score.Value.ToString();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateHealth()
    {
        healthSlider.value = health.Value; ;
    }
    
    public void UpdateScore()
    {
        scoreText.text = score.Value.ToString();
        scoreText.GetComponent<Animator>().Play(0);
    }

}
