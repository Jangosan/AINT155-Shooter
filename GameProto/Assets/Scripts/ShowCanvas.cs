using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour {


    public Canvas canvasToShow;  

    private void Start()
    {           
        canvasToShow.enabled = false;       
    }

    public void enableCanvas()
    {       
        canvasToShow.enabled = true;
    }

    public void disableCanvas()
    {
        canvasToShow.enabled = false;
    }


}
