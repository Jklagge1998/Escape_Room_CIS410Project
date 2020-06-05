using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public string sceneName;

    bool m_IsPlayerAtExit;
    float m_Timer;


    void OnTriggerEnter(Collider other)
    {
     

       if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            //EndScene();
            //SceneManager.LoadScene(sceneName);
            if (gameObject.tag == "Slime")
            {
                EndScene();
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
            
        }
    }

    void EndScene ()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
