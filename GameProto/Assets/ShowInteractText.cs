using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractText : MonoBehaviour {

    private Text interactText, reloadText;
	// Use this for initialization
	void Start () {
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
        interactText.enabled = false;
        reloadText = GameObject.Find("ReloadText").GetComponent<Text>();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && reloadText.enabled != true)
        {
            interactText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactText.enabled = false;
        }
    }
}
