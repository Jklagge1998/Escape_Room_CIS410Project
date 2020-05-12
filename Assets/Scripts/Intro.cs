using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public float start_time = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, start_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
