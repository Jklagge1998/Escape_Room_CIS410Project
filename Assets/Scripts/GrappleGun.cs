using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrappleGun : MonoBehaviour
{
    // public variables
   // public Color higlightPickup;
    public float range; // pickup range of grapple gun
    public Camera fpsCamera;
    public CanvasGroup DefaultplayerCursor;
    public CanvasGroup playerCursonOverPickup;
    //public Image playerCursorOverPickUp;

    // private variables
    private bool isHoldingObj;
    private Color orignalPlayerCursorColor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(fpsCamera.gameObject.transform.position, fpsCamera.gameObject.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.transform.gameObject.tag == "Pickup")
            {
                // reticle updates to blue when player is hovering over pickup item in range
                print("has hit box");
                DefaultplayerCursor.alpha = 0;
                playerCursonOverPickup.alpha = 1;
            }
            else
            {
                // if recticle was blue it turns to default. Otherwise it remains the same.
                playerCursonOverPickup.alpha = 0;
                DefaultplayerCursor.alpha = 1;
                
            }
        }
        else
        {
            // if recticle was blue it turns to default. Otherwise it remains the same.
            playerCursonOverPickup.alpha = 0;
            DefaultplayerCursor.alpha = 1;
        }
        
    }
}
