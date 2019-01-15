using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour {

    public int Value = 10;
    private int health;
    private int healthMax;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //gets the health and max health from the player
        collision.SendMessage("returnHealth", gameObject);

        //if health isn't full
        if (health != healthMax)
        {
            //if health + the value of the health pickup are greater than the maximum health, subtract the amount needed to reach from the orb value and remove it from the orb
            if (health + Value > healthMax)
            {
                collision.transform.SendMessage("pickupRestoreHealth", Value);
                Value = (health + Value) - healthMax;
            }
            // if the health + the amount provided by the orb are less than or equal to the max, the value is added to the health and the orb is removed
            else if ((health + Value) <= healthMax)
            {
                collision.transform.SendMessage("pickupRestoreHealth", Value);
                Destroy(gameObject);
            }
        }
        else
        {
            return;
        }
        
        
    }

    //stores the health and max health sent back from the returnHealth method
    public void setCurrentHealth(int[] healthInfo)
    {
        health = healthInfo[0];
        healthMax = healthInfo[1];
    }
}
