using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIWeapon : MonoBehaviour {

    //the health bar slider in the ui
    public Text ammoClip;
    public Text ammoReserve;
    public Text weapName;

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
