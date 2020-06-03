using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    public AudioSource audio_source;
    //public Button loadingScreen;
    public CanvasGroup sceneTransition;
    public GameObject Menu;
    public GameObject TimesToBeat;
   
   public void SceneLoader(string scene)
    {
        audio_source.mute = true;
        sceneTransition.alpha = 1;
        Menu.SetActive(false);
        SceneManager.LoadScene(scene);
    }
   
    public void displayPanel()
    {
        Menu.SetActive(false);
        TimesToBeat.SetActive(true);
    }

    public void backToMenu()
    {
        TimesToBeat.SetActive(false);
        Menu.SetActive(true);
    }
}
