using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text Timer_Text;
    private float start_time;
    private bool finished = false;
    public Text highScore;

    void Start()
    {
        start_time = Time.time;
        highScore.text = PlayerPrefs.GetFloat("Intro_High_Score", 99999).ToString();
        
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

        float score = Time.time - start_time;

        if (score < PlayerPrefs.GetFloat("Intro_High_Score", 99999))
        {
            Timer_Text.color = Color.green;
            PlayerPrefs.SetFloat("Intro_High_Score", score);
            Debug.Log("Changed high score");
            highScore.text = score.ToString();
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
        highScore.text = "0";
    }
}

//Followed this tutorial: https://www.youtube.com/watch?v=x-C95TuQtf0


