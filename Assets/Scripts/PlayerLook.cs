using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // public variables
    public Transform Playerbody;
    public float mouseSensitivity;
    public Transform GunPosition;

    // private variables
    private float xRotation = 0f;
    private Vector3 originalGunPosition;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // locks player's mouse cursor to middle of screen.
        originalGunPosition = GunPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        // update camera rotation based on users mouse input
        // Note: Using Time.deltaTime to move player by time not frame rate
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // looking up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limits player's camera up/down movement to 180 degrees 
        GunPosition.localRotation = transform.localRotation;
        
        // rotate player
        Playerbody.Rotate(Vector3.up * mouseX); // looking side to side

    }
}