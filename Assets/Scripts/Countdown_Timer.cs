using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown_Timer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 180.1f;
    public string sceneName;

    [SerializeField] Text countdown_text;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        countdown_text.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        float seconds = (currentTime % 60);
        //Debug.Log("Seconds: " + seconds.ToString());
        if (seconds >= 59 && seconds < 60)
        {
            countdown_text.text = "Time Left: " + minutes + ": 59";
        }
        else
        {
            countdown_text.text = "Time Left: " + minutes + ":" + seconds.ToString("00");
        }
        //string fraction = ((currentTime * 100) % 100).ToString("000");


        if (currentTime <= 0)
        {
            countdown_text.text = "0.00";
            SceneManager.LoadScene(sceneName);
        }
        else if (currentTime <= (startingTime * .50))
        {
            countdown_text.color = Color.red;
        }
        else if (currentTime <= (startingTime * .80))
        {
            countdown_text.color = Color.yellow;
        }
    }
}
