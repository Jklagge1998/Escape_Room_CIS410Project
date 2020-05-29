using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text Timer_Text;
    private float start_time;
    private bool finished = false;

    void Start()
    {
        start_time = Time.time;
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
        Timer_Text.color = Color.yellow;
        finished = true;

    }
}

//Followed this tutorial: https://www.youtube.com/watch?v=x-C95TuQtf0
