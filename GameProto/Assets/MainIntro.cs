using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//A stripped down version of the terminal functionality

public class MainIntro : MonoBehaviour {


    //the canvas containing the entire ui for the terminal
    public Canvas terminalUI;

    //the transform of the startup screen canvas and the transform of the entire terminal ui
    public Transform mainScreen, terminalTrans;

    //the button on the main screen
    private GameObject mainScreenBtn;

    //the animators for the main screen
    private Animator logoAnimator, scanLinesAnimator;

    // Use this for initialization
    void Start () {

        terminalTrans = terminalUI.transform;
        terminalUI = transform.GetComponentInChildren<Canvas>();
        mainScreenBtn = mainScreen.Find("Continue").gameObject;
        mainScreenBtn.SetActive(false);
        terminalUI.enabled = false;
        mainScreen = gameObject.transform.Find("TerminalUI").Find("Main Screen");
        logoAnimator = mainScreen.Find("IRCLogo").GetComponent<Animator>();
        scanLinesAnimator = mainScreen.Find("ScanLines").GetComponent<Animator>();

        StartCoroutine(terminalStart());

    }

    // Update is called once per frame
    void Update () {
		
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
}
