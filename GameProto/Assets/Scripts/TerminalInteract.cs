using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalInteract : MonoBehaviour {


    public Canvas terminalUI;
    private AudioSource terminalActivateSound;
	// Use this for initialization
	void Start () {
        terminalUI = transform.GetComponentInChildren<Canvas>();
        terminalActivateSound = transform.GetComponent<AudioSource>();
        terminalUI.enabled = false;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //if the player is within the trigger bounds and the player presses the interact button, the terminal ui will open and the appropriate sound will play
        if (collision.tag == "Player" && Input.GetButton("Interact") && !terminalUI.enabled)
        {            
            terminalUI.enabled = true;
            Cursor.visible = true;
            if (terminalActivateSound != null)
            {
                terminalActivateSound.Play();
            }
        }
        
    }


}
