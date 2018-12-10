using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUIControls : MonoBehaviour {
    
    public GameObject[] terminalScreens;
    private GameObject currentScreen;
    private Transform parentCanvas;

    private void Start()
    {

        //get the parent canvas for the terminal
        parentCanvas = gameObject.transform.parent.parent;

        //used to set the length of the array for storing the different screens
        int terminalScreenCount = 0;

              
        //loop through
        for(int i = 0; i < parentCanvas.childCount; i++)
        {
            if (parentCanvas.GetChild(i).tag == "TerminalScreen")
            {
                terminalScreenCount = terminalScreenCount + 1;
            }
        }
        print(terminalScreenCount);

        
        terminalScreens = (GameObject[])gameObject.        

        
        for (int i = 0; i < parentCanvas.childCount; i++)
        {
            if (parentCanvas.GetChild(i).tag == "TerminalScreen")
            {
                terminalScreens[i] = parentCanvas.GetChild(i).gameObject; 
            }
        }
        


    }

    public void Next()
    {
        for (int i = 0; i < terminalScreens.Length; i++)
        {
            if (terminalScreens[i].activeSelf == true)
            {               
                if (i + 1 <= terminalScreens.Length - 1)
                {
                    i++;
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

    public void Prev()
    {
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
}
