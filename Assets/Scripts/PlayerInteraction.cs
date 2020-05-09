using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // public variables
    public Color interactColor; // color highlighted when the player approaches an equipable or collectable item
    public float maxInteractionDistance;
    public Text InteractMessageBox;
    public GameObject playerTool; // portal gun for now, hopefully will be adapted to an array of all the player's tools
    public Camera fpsCamera;
    public LayerMask playerMask; // we want to ingore the player when raycasting

    // private variables
    private Color currOriginalColor; // will hold highlighted items original color
    private Color prevOriginalColor;
    private GameObject currObj; // current Collectible or Equipable
    private GameObject prevObj; // previous Collectible or Equipable
    // Start is called before the first frame update
    void Start()
    {
        InteractMessageBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        //Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
        //Vector3 origin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,0));
        //Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); // ray is in center of player screen
        Ray ray = new Ray(fpsCamera.gameObject.transform.position, fpsCamera.gameObject.transform.forward);
        Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 2), Color.blue);
        Debug.DrawLine(fpsCamera.gameObject.transform.position, fpsCamera.gameObject.transform.position + Vector3.forward, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxInteractionDistance))
        {
            print("hit " + hit.transform.gameObject.name);
            // raycast has hit an object within the maxInteractionDistance
            if (hit.transform.gameObject.tag == "equipable" || hit.transform.gameObject.tag == "collectible")
            {
                // update current
                currObj = hit.transform.gameObject;
                currOriginalColor = currObj.GetComponent<Renderer>().material.color; // store original color
                currObj.GetComponent<Renderer>().material.color = interactColor; // highlight object with interactColor   
                setInteractMessage(currObj, false);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    // user has pressed F to interact 
                    SetInteractMode(currObj);
                }

                if (currObj != prevObj)
                {
                    resetObjColor(prevObj);
                    // set curr to prev
                    prevOriginalColor = currOriginalColor;
                    prevObj = currObj;
                }
            }
            else
            {
                // raycast didn't hit a collectible or equipable
                resetObjColor(prevObj);
                setInteractMessage(prevObj, true);
            }

        }
        else
        {
            // raycast has hit no colliders
            resetObjColor(prevObj);
            setInteractMessage(prevObj, true);
        }
    }

    private void resetObjColor(GameObject prev)
    {
        if (prev != null)
        {
            // reset prev color
            prev.GetComponent<Renderer>().material.color = prevOriginalColor;
        }
    }

    private void setInteractMessage(GameObject obj, bool hide)
    {
        if (hide)
        {
            InteractMessageBox.text = "";
        }
        else if (obj.tag == "equipable")
        {
            InteractMessageBox.text = "Press F to equip";
        }
        else if (obj.tag == "collectible")
        {
            InteractMessageBox.text = "Press F to collect";
        }

    }

    private void SetInteractMode(GameObject obj)
    {
        if (obj.tag == "equipable")
        {
            equip(obj);
        }
    }

    private void equip(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
            if (obj.name == playerTool.tag) ;
            {
                playerTool.SetActive(true);
            }
        }
    }
}
