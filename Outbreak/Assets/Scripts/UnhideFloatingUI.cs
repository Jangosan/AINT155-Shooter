using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnhideFloatingUI : MonoBehaviour {

    public Canvas floatingUI;
	void Start () {
        floatingUI.enabled = false;
	}
	
	public void unhideUI()
    {
        floatingUI.enabled = true;
    }

    public void hideUI()
    {
        floatingUI.enabled = false;
    }
}
