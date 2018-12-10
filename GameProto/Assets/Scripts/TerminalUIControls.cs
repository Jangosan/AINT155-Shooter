using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TerminalUIControls : MonoBehaviour {
    
    public GameObject[] terminalScreens;
    private GameObject currentScreen;
    public Canvas terminalUI;
    public Transform mainScreen, terminalTrans;
    private AudioSource terminalActivateSound;
    private Animator logoAnimator, scanLinesAnimator;
    public UnityEvent pause, unpause;
    private AudioSource terminalOn;


    private void Start()
    {
        terminalOn = gameObject.GetComponent<AudioSource>();
        terminalTrans = terminalUI.transform;
        terminalUI = transform.GetComponentInChildren<Canvas>();
        terminalActivateSound = transform.GetComponent<AudioSource>();
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

    //When the next button is clicked, the terminal transitions to the next screen
    public void Next()
    {
        print("next!");
        for (int i = 0; i < terminalScreens.Length; i++)
        {
            if (terminalScreens[i].activeSelf == true)
            {               
                if (i + 1 <= terminalScreens.Length - 1)
                {
                    i++;
                    print(terminalScreens[i].name);
                }
                currentScreen = terminalScreens[i];
                print(currentScreen.name);
                currentScreen.SetActive(true);
                
            }
            else
            {
                terminalScreens[i].SetActive(false);
            }
        }

        
    }


    //When the prev button is clicked, the terminal transitions to the previous screen
    public void Prev()
    {
        print("prev!");
        for (int i = 0; i < terminalScreens.Length; i++)
        {
            if (terminalScreens[i].activeSelf == true)
            {
                if(i - 1 >= 0)
                {
                    i--;
                }
                currentScreen = terminalScreens[i];
                currentScreen.SetActive(true);
                return;
            }
            else
            {
                terminalScreens[i].SetActive(false);
            }
        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {

        //if the player is within the trigger bounds and the player presses the interact button, the terminal ui will open and the appropriate sound will play
        if (collision.tag == "Player" && Input.GetButton("Interact") && !terminalUI.enabled)
        {

            terminalOn.Play();
            pause.Invoke();
            StartCoroutine(terminalStart());
            Cursor.visible = true;
            if (terminalActivateSound != null)
            {
                terminalActivateSound.Play();
            }
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
        StartCoroutine(goToFirstScreen());
    }
    //After the inital animation is finished, the first terminal screen will be loaded
    IEnumerator goToFirstScreen()
    {
        print("Waiting");
        yield return new WaitForSecondsRealtime(3.0f);        
        Next();
    }
    public void Exit()
    {
        unpause.Invoke();
        logoAnimator.Play("Idle");
        scanLinesAnimator.Play("Idle");
        terminalUI.enabled = false;
        
    }
}
