using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{

    public MainCamera portalcameras;
    private Quaternion  originalrotation;
    private Quaternion  desiredrotation;  
    private bool isup;
    private bool desiredisup;
    // Start is called before the first frame update
    void Start()
    {
        isup = true;
        desiredisup = true;
        originalrotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        desiredrotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isup && desiredisup == false){
            
            transform.rotation = desiredrotation;
            isup = false;
        }
        else if (!isup && desiredisup == true){
            
            transform.rotation = originalrotation;
            isup = true;
        }
        
    }

    private void switchlever()
    {
        if(desiredisup){
            desiredisup = false;
            portalcameras.SendMessage("activatePortal");
        }
        else{
            desiredisup = true;
            portalcameras.SendMessage("deactivatePortal");
        }
    }
}
