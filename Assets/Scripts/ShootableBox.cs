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
    //public int box_count = 1;
    

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Debug.Log("Trigger being sent from shootable boxes");
            gate.Open();
            //platform.SendMessage("Show");
            //platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + 10f, platform.transform.position.z);
            //platform.SetActive(true);
            gameObject.SetActive(false);
            //box_count -= 1;
            //if (box_count == 0)
            //{
            //    platform.SetActive(true);
            //    gate.Open();
            //    //activated_object.SendMessage("Open");
            //    Debug.Log("Registered zero shootable boxes");

            //    if (activated)
            //    {
            //        activated = false;
            //        Debug.Log("Deactivated");
            //    }
            //    else
            //    {
            //        activated = true;
            //        Debug.Log("Activated");
            //    }


            //}
        }

    }
}