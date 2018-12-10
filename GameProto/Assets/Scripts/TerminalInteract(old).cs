using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalInteract : MonoBehaviour {


    public Canvas terminalUI;
    public Transform mainScreen;
    private AudioSource terminalActivateSound;
    private Animator logoAnimation, scanLines;
    

	// Use this for initialization
	void Start () {
        terminalUI = transform.GetComponentInChildren<Canvas>();
        terminalActivateSound = transform.GetComponent<AudioSource>();
        terminalUI.enabled = false;
        mainScreen = gameObject.transform.Find("TerminalUI").Find("Main Screen");
        logoAnimation = mainScreen.Find("IRCLogo").GetComponent<Animator>();
        scanLines = mainScreen.Find("ScanLines").GetComponent<Animator>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //if the player is within the trigger bounds and the player presses the interact button, the terminal ui will open and the appropriate sound will play
        if (collision.tag == "Player" && Input.GetButton("Interact") && !terminalUI.enabled)
        {            
            terminalUI.enabled = true;
            scanLines.enabled = true;
            scanLines.Play("ScanLines");
            logoAnimation.enabled = true;
            logoAnimation.Play("IRCLogoTerminalAnim");
            Cursor.visible = true;
            if (terminalActivateSound != null)
            {
                terminalActivateSound.Play();
            }
        }
        
    }


}
