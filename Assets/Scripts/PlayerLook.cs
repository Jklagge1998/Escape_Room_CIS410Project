using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // public variables
    public Transform Playerbody;
    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 50f;
    public float xRotation;
    public float yRotation;
    public bool mouseLock;
    public bool invertYaw;
    public bool invertTheta;
    // private variables


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // locks player's mouse cursor on screen.
    }

    // Update is called once per frame
    void Update()
    {
        // if condition ? true value  : false value
        //if (mouseLock )
        // update camera rotation based on users mouse input
        // Note: Using Time.deltaTime to move player by time not frame rate
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime * (mouseLock ? 0 : 1);
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime * (mouseLock ? 0 : 1);

        xRotation = xRotation + (invertTheta ? -mouseX : mouseX);

        yRotation = yRotation + (invertYaw ? mouseY : -mouseY);

        yRotation = Mathf.Clamp(yRotation, -45f, 89f); // Limits player's camera up/down movement to 180 degrees 

        mouseX = xRotation * Mathf.Deg2Rad;
        mouseY = yRotation * Mathf.Deg2Rad;

        Vector3 forward = new Vector3(0f, Mathf.Sin(mouseY), Mathf.Cos(mouseY));

        //Vector3 forward = new Vector3(Mathf.Cos(mouseX) * Mathf.Cos(mouseY), Mathf.Sin(mouseY), Mathf.Cos(mouseY) * Mathf.Sin(mouseX));
        transform.localRotation = Quaternion.LookRotation(forward, Vector3.up);
        forward = new Vector3(Mathf.Cos(mouseX), 0f, Mathf.Sin(mouseX));
        Playerbody.localRotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}