using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{
    public int currentHealth = 3;
    public bool activated = true;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

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
