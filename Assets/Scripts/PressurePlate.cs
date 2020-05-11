using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float pressDownDistance;

    private Vector3 originalPos;
    private Vector3 downedPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        downedPosition = new Vector3(originalPos.x, originalPos.y - pressDownDistance, originalPos.z);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Pickup")
        {
            print("object has entered space");
            transform.position = downedPosition;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Pickup")
        {

            transform.position = originalPos;
        }
       
    }
}
