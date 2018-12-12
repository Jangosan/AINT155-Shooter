using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour {

    public GameObject[] weapons = new GameObject[2];

	void Start () {
        //Loop through the player children and add any child game objects that are weapons to the weapons array
		for(int i = 0; i < gameObject.transform.childCount;)
        {
            if (gameObject.transform.GetChild(i).tag == "Weapon")
            {
                weapons[i] = gameObject.transform.GetChild(i).gameObject;
            }
            
        }
	}

    public void equipWeapon(GameObject weaponToEquip)
    {
        if (Input.GetButton("Interact"))
        {
            //if (weapons[1] = null || weapons[2] = null)
            //{

            //}
        }
    }


	
}
