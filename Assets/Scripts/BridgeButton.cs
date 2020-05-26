using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public int currentHealth = 1;
    public bool activated;
    //public int box_count;
    public Bridge bridge;
    public List<BridgeButton> buttons;

    void Start()
    {
        if (activated)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

    }

    private void colorChange()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        activated = false;
    }


    public void Damage(int damageAmount)
    {
        if (!activated)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            bridge.SendMessage("Move");
            foreach (BridgeButton button in buttons)
            {
                button.SendMessage("colorChange");
            }
        }
            

    }
}