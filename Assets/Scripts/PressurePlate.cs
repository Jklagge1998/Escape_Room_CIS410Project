using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
    // NOTES: to have this work the object this script is attached to must have the following components: 
             1) Transform (standard for any object in unity)
             2) Collider (set to isTrigger)
             3) Rigidbody (use Gravity disables and the xyz position & rotation Froze (under constraints)
    
    // Possible problems without these components
        * With the XYZ position & rotation unfrozen external forces (such as a bullet from a gun) can knock the pressure plates out of the map
        * To use ontriggerEnter and onTriggerExit the collider of the object this script is attached to needs to have its collider is trigger.
            * This means that the player will go through this object, but this object can be solid by adding another collider (on that isn't istriggered). 
    
    // Note: These specifications are based on default settings of these components except for the adjustments mentioned above.      
 */
public class PressurePlate : MonoBehaviour
{
    // public variables
    public float pressDownDistance; // how far the plates position will go down when triggered
    public bool triggered; // true if the plate is triggered (downed), false otherwise
    public List<string> triggerTags; // list of all object tags that will trigger the plate down

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
        int triggerFlag = 0;
        foreach (string tag in triggerTags)
        {
            if (other.gameObject.tag == tag)
            {
                triggerFlag++;
                break; // only need one trigger tag to activate
            }
        }

        if (triggerFlag == 1)
        {
            transform.position = downedPosition;
            triggered = true;
        }
  

    }

    private void OnTriggerExit(Collider other)
    {
        int triggerFlag = 0; 
        foreach(string tag in triggerTags)
        {
            if (other.gameObject.tag == tag)
            {
                triggerFlag++;
                break; // only need one trigger tag to activate
            }
        }

        if (triggerFlag == 1)
        {
            transform.position = originalPos;
            triggered = false;
        }


    }
}
