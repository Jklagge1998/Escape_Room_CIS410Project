using UnityEngine;


public class MainCamera : MonoBehaviour {
    private bool everyother;
    public bool activated = true;
    

    Portal[] portals;

    void Awake () {
        everyother = true;
        portals = FindObjectsOfType<Portal> ();
        if(!activated){
            foreach (Portal p in portals)
            {
                p.SendMessage("turnPortalOff");
            }
        }
        
    }

    void OnPreCull() {

        if (activated && everyother)
        {
            // for (int i = 0; i < portals.Length; i++)
            // {
            //     portals[i].PrePortalRender();
            // }
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].Render();
            }

            // for (int i = 0; i < portals.Length; i++)
            // {
            //     portals[i].PostPortalRender();
            // }
            everyother = false;
        }
        else{
            everyother = true;
        }


       

    }

    private void activatePortal(){
        activated = true;
        foreach (Portal p in portals)
            {
                p.SendMessage("turnPortalOn");
            }
    }

    private void deactivatePortal(){
        activated = false;
        foreach (Portal p in portals)
            {
                p.SendMessage("turnPortalOff");
            }
    }

}