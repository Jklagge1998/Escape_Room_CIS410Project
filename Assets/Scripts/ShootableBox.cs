using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{
    public int currentHealth = 1;
    public bool activated = true;
    //public int box_count;
    public Door gate;
    public GameObject platform;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Debug.Log("Trigger being sent from shootable boxes");
            gate.Open();
            platform.SendMessage("Show");
            gameObject.SetActive(false);
            //box_count -= 1;
            //if (box_count == 0)
            //{
            //    activated_object.SendMessage("Open");
            //    Debug.Log("Registered zero shootable boxes");
            //    //activated_object.SetActive(true);
            //}

            if (activated)
            {
                activated = false;
                Debug.Log("Deactivated");
            }
            else
            {
                activated = true;
                Debug.Log("Activated");
            }


        }

    }
}