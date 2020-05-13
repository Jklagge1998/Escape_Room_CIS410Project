﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public float threshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
        if (transform.position.y < threshold)
        {
            SceneManager.LoadScene(0);
        }
    }
}
