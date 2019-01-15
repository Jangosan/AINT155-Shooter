using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIWeapon : MonoBehaviour {

    //The dynamic elements in the ui for the weapon
    private Text ammoClip, weapName, ammoReserve;
    public WeaponFiringController onEnableWeaponValues;


    private void OnEnable()
    {
        Transform weaponInfoPanel = GameObject.FindGameObjectWithTag("AmmoUI").transform;
        ammoClip = weaponInfoPanel.Find("AmmoClip").GetComponent<Text>();
        ammoReserve = weaponInfoPanel.Find("AmmoReserve").GetComponent<Text>();
        weapName = weaponInfoPanel.Find("WeaponName").GetComponent<Text>();

        //gets the information about the weapon
        onEnableWeaponValues = gameObject.GetComponent<WeaponFiringController>();
        weapName.text = onEnableWeaponValues.weaponName;
        ammoClip.text = "" + onEnableWeaponValues.currentClip;
        ammoReserve.text = "" + onEnableWeaponValues.currentReserve;
    }

    public void setWeaponName(string name)
    {
        weapName.text = name;
    }

    private void updateAmmoCount(int[] ammoInfo)
    {        
        ammoClip.text = ammoInfo[0].ToString();
        ammoReserve.text = ammoInfo[1].ToString();
    }
}
