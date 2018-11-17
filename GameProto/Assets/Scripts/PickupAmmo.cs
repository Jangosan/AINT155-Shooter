using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmo : MonoBehaviour {

    //the initial number of clips in the pickup
    public int numberOfClips;

    //the amount of ammo remaining in the pickup
    public int ammoAmount = 0;

    //variables from the equipped weapon
    private int clipSize, maxAmmo, currentAmmo;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //sends a message to the equipped weapon of the player to return the clip size, max ammo and current ammo
        collision.transform.GetChild(0).SendMessage("returnAmmoInfo", gameObject);

        //if the amount of ammo supplied by the pickup would go over the maximum amount for the weapon, the amount needed to get to max is subtracted from the amount in the pickup but the pickup isn't destroyed
        if (currentAmmo + ammoAmount > maxAmmo)
        {
            collision.transform.GetChild(0).SendMessage("pickupRestoreAmmo", (maxAmmo - currentAmmo));
            ammoAmount = ammoAmount - (maxAmmo - currentAmmo);
        }
        //the pickup is destroyed and any ammo in it is supplied to the player
        else
        {
            collision.transform.GetChild(0).SendMessage("pickupRestoreAmmo", (ammoAmount));
            Destroy(gameObject);
        }

    }

    //set the maxAmmo and currentAmmo based off the returned information from the WeaponFiringController Class
    public void setCurrentAmmo(int[] ammoInfo)
    {
        //the max ammo amount of the weapon
        maxAmmo = ammoInfo[0];
        //the current amount of ammo held by the player
        currentAmmo = ammoInfo[1];
        //the clip size for the carried weapon
        clipSize = ammoInfo[2];

        //if the ammoAmount is the default, set it to the number of clips * clip size
        if (ammoAmount == 0)
        {
            ammoAmount = numberOfClips * clipSize;
        }
    }
}
