using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}


    public delegate void SendScore(int theScore);
    public static event SendScore OnSendScore;

    public int score = 10;
    //public int scoreToAdd = 3;

    public void OnDestroy()
    {
        if(OnSendScore != null)
        {
            OnSendScore(score);
        }
        //return score;
    }
}
