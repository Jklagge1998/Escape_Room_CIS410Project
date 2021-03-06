﻿/*
Credit to https://github.com/SebLague/Portals/tree/master for providing much of the underlying code.
*/
using UnityEngine;


public class MainCamera : MonoBehaviour {
    public bool activated = true;
    

    Portal[] portals;

    void Awake () {

        portals = FindObjectsOfType<Portal> ();
        if(!activated){
            foreach (Portal p in portals)
            {
                p.SendMessage("turnPortalOff");
            }
        }
        
    }

    void OnPreCull() {

        if (activated)
        {
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].Render();
            }
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