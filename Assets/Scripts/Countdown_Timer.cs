using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown_Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
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
        countdown_text.text = currentTime.ToString("f2");

        if (currentTime <= 0)
        {
            countdown_text.text = "0.00";
            SceneManager.LoadScene(sceneName);
        }
        else if (currentTime <= 10)
        {
            countdown_text.color = Color.red;
        }
        else if (currentTime <= 20)
        {
            countdown_text.color = Color.yellow;
        }
    }
}
