using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInformation : MonoBehaviour {

    public GameObject weaponPrefab;

    //Function for getting the weapon prefab tied to the pickup
    public GameObject sendWeaponInfo()
    {
        return weaponPrefab;
    }
}
