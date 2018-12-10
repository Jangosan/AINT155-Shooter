using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipWeapon : MonoBehaviour {

    public Transform[] weapons = new Transform[2];

	void Start () {
		for(int i = 0; i < gameObject.transform.childCount;)
        {
            if (gameObject.transform.GetChild(i).tag == "Weapon")
            {
                weapons[i] = gameObject.transform.GetChild(i);
            }
        }
	}
	
}
