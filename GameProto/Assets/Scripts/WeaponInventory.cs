using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour {

    WeaponInformation weaponInfo;

    //the array index of the currently equipped weapon
    public int currentWeapon;

    //Set the current weapon to the first child of the player
	void Start () {
        currentWeapon = 0;
    }

    //when the player presses one of the number keys, the weapon tied to that key will be equipped
    private void FixedUpdate()
    {
        for(int i = 1; i < 10; i++)
        {
            if(Input.GetKey("" + i))
            {
                if(transform.childCount >= i)
                {
                    currentWeapon = i - 1;
                    SwitchWeapon(i - 1);
                }
                
            }
        }
    }

    //equip the weapon
    public void EquipWeapon(GameObject weaponToEquip)
    {
        GameObject newWeapon;
        newWeapon = Instantiate(weaponToEquip, gameObject.transform, false);
        newWeapon.SetActive(true);
        currentWeapon++;
        SwitchWeapon(currentWeapon);
    }

    //set the child at the index to active and all the others to inactive
    private void SwitchWeapon(int weaponIndex)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i == weaponIndex)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    //get the weapon prefab when the player collides with the pickup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        weaponInfo = collision.GetComponent<WeaponInformation>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //if the player is colliding with a weapon and the interact button is pressed, then the weapon is equipped and the pickup is removed
        if (collision.gameObject.tag == "Weapon")
        {                 
                EquipWeapon(weaponInfo.sendWeaponInfo());
                Destroy(collision.gameObject);
        }
    }

}
