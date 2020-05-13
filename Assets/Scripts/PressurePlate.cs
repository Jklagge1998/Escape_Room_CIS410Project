using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // public variables
    public float pressDownDistance; // how far the plates position will go down when triggered
    public bool triggered; // true if the plate is triggered (downed), false otherwise

    // private variables
    private Vector3 originalPos; // plate position when not triggered
    private Vector3 downedPosition; // plate position when triggered

    // Start is called before the first frame update
    void Start()
    {
        // initializing variables
        originalPos = transform.position;
        downedPosition = new Vector3(originalPos.x, originalPos.y - pressDownDistance, originalPos.z);
        triggered = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Pickup")
        {
            // player or pickup has collided with the plate. Thus the plate should be triggered
            print("object has entered space");
            transform.position = downedPosition;
            triggered = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Pickup")
        {
            // player or pikup has left the plate. Thus the plate should be untriggered.
            transform.position = originalPos;
            triggered = false;
        }

    }
}
