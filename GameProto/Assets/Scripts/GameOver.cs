using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {


    public Canvas gameOverCanvas;
    public ControlPlayer playerControlScript;
    public WeaponFiringController[] weaponScript;

    private void Start()
    {
        Time.timeScale = 1;
       

        

        gameOverCanvas.enabled = false;

        weaponScript = new WeaponFiringController[gameObject.transform.childCount];

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {            
            print(gameObject.transform.GetChild(i).GetComponent<WeaponFiringController>());
            weaponScript[i] = gameObject.transform.GetChild(i).GetComponent<WeaponFiringController>();
            
        }
        
    }
    public void enableGameOver()
    {

        Time.timeScale = 0;

        playerControlScript.enabled = false;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            weaponScript[i].enabled = false;
        }
        
        gameOverCanvas.enabled = true;
    }
}
