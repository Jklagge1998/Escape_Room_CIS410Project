using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
