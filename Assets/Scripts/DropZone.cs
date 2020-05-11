using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    /*
    public bool collectionIsActive = true;
    public bool pickupHasEntered;
    public Text itemCountMessage;
    public Text itemsCollectedMessage;
    public string pickupType;
    public int RequiredPickups;
    private int pickupCount;
    public Pickup[] pickups;
    // Start is called before the first frame update
    private Pickup pickup;
    private void Start()
    {
        pickupHasEntered = false;
        pickupCount = 0;
        itemCountMessage.text = pickupType + " : " + pickupCount;
        itemsCollectedMessage.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Pickup")
        {
            
            print(other.gameObject.name);
            foreach (Pickup p in pickups)
            {
                print(p.name);
                if (p.gameObject == other.gameObject)
                {
                    print("matched");
                    p.drop();
                    p.activated = false;
                    p.message.text = "";
                    p.resetColor();
                }
            }
            
            //pickupHasEntered = true;
            pickupCount += 1;
            itemCountMessage.text = pickupType + " : " + pickupCount;
            
           // print("ball is in dropzone");
        }
        if (pickupCount >= RequiredPickups)
        {
            itemsCollectedMessage.text = "You have collected " + RequiredPickups + " " + pickupType + ".";
        }
    }
    */
}
