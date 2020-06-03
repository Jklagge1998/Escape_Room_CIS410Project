using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text Timer_Text;
    private float start_time;
    private bool finished = false;
    public Text highScore_label;
    private float highScore = 60;
    //public float highScore;


    void Start()
    {
        start_time = Time.time;
        highScore_label.text = highScore.ToString();
        Debug.Log("Starting high score is:");
        Debug.Log(highScore.ToString());
        
    }

    void Update()
    {
        if (finished)
        {
            return;
        }

        float t = Time.time - start_time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        Timer_Text.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        //Timer_Text.color = Color.yellow;
        Debug.Log("Score is: ");
        float score = Time.time - start_time;

        Debug.Log(score.ToString());
        Debug.Log("highScore is: ");
        Debug.Log(highScore.ToString());

        if (score <= highScore)
        {
            Timer_Text.color = Color.green;
            //PlayerPrefs.SetFloat("Intro_High_Score", score);
            //Debug.Log("Changed high score");
            //highScore_label.text = score.ToString();
        }
        else
        {
            Timer_Text.color = Color.red;
        }

        finished = true;

    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Intro_High_Score");
        //highScore_label.text = "0";
    }
}

//Followed this tutorial: https://www.youtube.com/watch?v=x-C95TuQtf0


