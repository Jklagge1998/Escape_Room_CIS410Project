using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    // How much to move this object.
    public Vector3 moveBy;

    //List of linked bridges
    public List<Bridge> bridges;

    // How long the movement should take, in seconds.
    public float transitionTime;
    private bool moving;
    public bool startingup;

    private Vector3 downposition;
    private Vector3 upposition;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private bool isup;
    private float moveTime;
  


    void Start()
    {
 

        moving = false;
        // Record our starting position so that we can 
        // lerp to the target position smoothly.
        upposition = transform.position;

        // Add how much we want to move by to the start position.
        // This is where we want to end up.
        downposition = upposition + moveBy;

        // This tracks how long we've been moving for, in seconds.
        moveTime = 0.0f;

        if (!startingup)
        {
            MoveDown();
        }
        else
        {
            isup = true;
        }
    }

    void Update()
    {
        // Check if we're close enough to the target. 
        // Replace Mathf.Epsilon with something else if you want to have a different
        // closeness threshold. 
        if (moving == true && Vector3.Distance(targetPosition, transform.position) > Mathf.Epsilon)
        {

            moveTime += Time.deltaTime;

            // Lerp from start to target position. 
            // Note that "moveTime / transitionTime" will equal 1 when we reach the target, which
            // is exactly what we want.
            transform.position = Vector3.Lerp(startPosition, targetPosition, moveTime / transitionTime);
        }
        else
        {
            moving = false;
            moveTime = 0.0f;
        }
    }

    private void Move()
    {
        Debug.Log("Got Move");
        if (isup)
        {
            Debug.Log("Got Move Down");
            MoveDown();
        }
        else
        {
            Debug.Log("Got Move Up");
            MoveUp();
        }
    }

    private void MoveUp()
    {
        moving = true;
        targetPosition = upposition;
        startPosition = downposition;
        isup = true;
        foreach (Bridge bridge in bridges)
        {
            bridge.SendMessage("MoveDown");
        }
    }

    private void MoveDown()
    {
        moving = true;
        targetPosition = downposition;
        startPosition = upposition;
        isup = false;
    }
}
