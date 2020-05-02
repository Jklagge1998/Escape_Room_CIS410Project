using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    /*Requirements to use
         */
    // public variables

    public Color selectedColor; //When the mouse hovers over the GameObject, it turns to this color
    public GameObject player;
    public float MaxPickupDistance;
    public Text message;
    public string PickupMessage;
    public string dropMessage;
    public DropZone dropzone;

    // private variables
    private Color OriginalColor;  //This stores the GameObject’s original color
    private MeshRenderer Renderer; //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    private bool holding = false;
    private string currentMessage;
    public bool activated = true;
    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        OriginalColor = Renderer.material.color;
        // set message to blank
        message.text = "";
        currentMessage = PickupMessage;
    }
    void Update()
    {

    }
    void OnMouseOver()
    {
        if (activated)
        {
            // Change the color of the GameObject to red when the mouse is over GameObject
            // using raycast to incorporate maxPickUp distance
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, MaxPickupDistance))
            {
                Renderer.material.color = selectedColor;
                message.text = currentMessage;
                if (Input.GetKeyDown(KeyCode.F) && !holding)
                {

                    pickup();


                }
                else if (Input.GetKeyDown(KeyCode.F) && holding)
                {
                    drop();


                }
            }
            else
            {
                Renderer.material.color = OriginalColor;
                message.text = "";
            }

        }
    }

    void OnMouseExit()
    {
        if (activated)
        {
            // Reset the color of the GameObject back to normal
            Renderer.material.color = OriginalColor;
            message.text = "";
            //drop();
        }
    }

    void pickup()
    {
        // put object in center of camera and turn off gravity of it to hold it still
        holding = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.SetParent(player.transform);
       
        currentMessage = dropMessage;
    }

    public void drop()
    {
        // deactive the effects of pickup
        holding = false;
        Vector3 objectPos = transform.position;
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
        transform.position = objectPos;
        currentMessage = PickupMessage;
        /*
        if (dropzone.pickupHasEntered == true)
        {
            activated = false; // deactivate
            dropzone.pickupHasEntered = false;
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if object is being held and collides with another object it is dropped.
        if (holding)
        {
            drop();
        }
    }

    public void resetColor()
    {
        Renderer.material.color = OriginalColor;
    }

}


