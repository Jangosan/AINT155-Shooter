using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TerminalUIControls : MonoBehaviour {
    
    //an array of the different terminal pages
    public GameObject[] terminalScreens;

    //The index of the current screen that is active
    private int currentScreen;

    //the canvas containing the entire ui for the terminal
    public Canvas terminalUI;

    //the transform of the startup screen canvas and the transform of the entire terminal ui
    public Transform mainScreen, terminalTrans;

    private GameObject mainScreenBtn;

    private Animator logoAnimator, scanLinesAnimator;
    public UnityEvent startUp, shutDown;
    private AudioSource terminalOn;


    private void Start()
    {
        terminalOn = gameObject.GetComponent<AudioSource>();
        terminalTrans = terminalUI.transform;
        terminalUI = transform.GetComponentInChildren<Canvas>();
        mainScreenBtn = mainScreen.Find("Continue").gameObject;
        mainScreenBtn.SetActive(false);
        terminalUI.enabled = false;
        mainScreen = gameObject.transform.Find("TerminalUI").Find("Main Screen");
        logoAnimator = mainScreen.Find("IRCLogo").GetComponent<Animator>();
        scanLinesAnimator = mainScreen.Find("ScanLines").GetComponent<Animator>();
        


        //used to set the length of the array for storing the different screens
        int terminalScreenCount = 0;


        //loop through the children and if they have the terminal screen tag, terminalScreenCount will be increased by 1
        for (int i = 0; i < terminalTrans.childCount; i++)
        {
            if (terminalTrans.GetChild(i).tag == "TerminalScreen")
            {
                terminalScreenCount = terminalScreenCount + 1;
            }
        }

        //assign the value of terminal screens
        terminalScreens = new GameObject[terminalScreenCount];

        //loop through the children and if they have the terminal screen tag, they will be added to the array
        for (int i = 0; i < terminalTrans.childCount; i++)
        {
            if (terminalTrans.GetChild(i).tag == "TerminalScreen")
            {
                terminalScreens[i] = terminalTrans.GetChild(i).gameObject;
            }
        }

        //Set the main screen as the default screen
        for (int i = 0; i < terminalScreens.Length; i++)
        {
            if (terminalScreens[i].name == "Main Screen")
            {
                terminalScreens[i].SetActive(true);
                
            }
            else
            {
                terminalScreens[i].SetActive(false);
            }
        }       
    }

    //When the next button is clicked, the terminal transitions to the next screen. +1 moves forwards, -1 moves backwards, other values can also be used to go to specific screens in the array
    public void switchPage(int indexDirection)
    {
        for (int i = 0; i < terminalScreens.Length; i++)
        {
            if (terminalScreens[i].activeSelf)
            {
                terminalScreens[i].SetActive(false);

                if (i + indexDirection < terminalScreens.Length)
                {
                    currentScreen = i + indexDirection;
                }
                
            }
        }

        terminalScreens[currentScreen].SetActive(true); 

        
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {

        //if the player is within the trigger bounds and the player presses the interact button, the terminal ui will open and the appropriate sound will play
        if (collision.tag == "Player" && Input.GetButton("Interact") && !terminalUI.enabled)
        {
            terminalOn.Play();
            startUp.Invoke();
            StartCoroutine(terminalStart());
            
        }

    }

    IEnumerator terminalStart()
    {
        yield return new WaitForSecondsRealtime(0.453f);
        terminalUI.enabled = true;
        scanLinesAnimator.enabled = true;
        scanLinesAnimator.Play("ScanLines");
        logoAnimator.enabled = true;
        logoAnimator.Play("IRCLogoTerminalAnim");
        yield return new WaitForSecondsRealtime(3.0f);
        Cursor.visible = true;
        mainScreenBtn.SetActive(true);

    }


    public void Exit()
    {
        shutDown.Invoke();
        Cursor.visible = false;
        logoAnimator.Play("Idle");
        terminalUI.enabled = false;
        
    }
}
