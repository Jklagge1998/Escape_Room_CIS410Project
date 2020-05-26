using UnityEngine;

public class MainCamera : MonoBehaviour {

    public bool activated = true;

    Portal[] portals;

    void Awake () {
        portals = FindObjectsOfType<Portal> ();
    }

    void OnPreCull() {

        if (activated)
        {
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].PrePortalRender();
            }
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].Render();
            }

            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].PostPortalRender();
            }
        }

       

    }

}