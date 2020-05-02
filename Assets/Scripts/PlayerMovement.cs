using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Public Variables
    public CharacterController playerController;
    public float playerMovementSpeed;
    public float gravity; // -9.81f by default
    public float playerJumpHeight;
    public Transform groundCheck; // postion of object that will be checked to see if player hits the ground
    public float groundCheckRadius; // radius of the search for a ground collider
    public LayerMask groundMask; // layer of componet groundCheck collides with. We will see if the object has a ground layer.
    public GameObject bulletPrefab;
    public Camera playerCamera;

    // Private Variables
    private Vector3 currentVelocity;
    private bool isOnGround;
    // Update is called once per frame
    void Update()
    {
        // Check to see if the player is on the ground. 
        isOnGround = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (isOnGround && currentVelocity.y < 0)
        {
            // reset Velocity. Note: It doesn't reset to 0 because isOnGround might register before the player has hit the ground
            currentVelocity.y = -2f; // this allows the player get to the ground
        }
        // Get player input from users keyboard input (using unity axis inputs)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;

        // apply direction to player movement
        playerController.Move(moveDirection * playerMovementSpeed * Time.deltaTime);

        // check to see if the player is jumping
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            currentVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravity);
        }

        // incorporate velocity and gravity to player movement
        currentVelocity.y += gravity * Time.deltaTime;

        //Physics for free fall
        playerController.Move(currentVelocity * Time.deltaTime); // call deltaTime again to satisfy equation: delta y = (1/2 gravity * t^2) 

        //if (Input.GetMouseButtonDown(0))
        //{
        //    GameObject bulletObject = Instantiate(bulletPrefab);
        //    bulletObject.transform.position = playerCamera.transform.position  + playerCamera.transform.forward;
        //}
    }
}
