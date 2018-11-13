using UnityEngine;
using UnityEngine.Events;

public class AddScore : MonoBehaviour {

    public int pointsToAdd = 10;
    public IntVariable score;

    public UnityEvent onScore;

    public void DoSendScore()
    {
        score.Value += pointsToAdd;
        onScore.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoSendScore();
        }
    }
}
