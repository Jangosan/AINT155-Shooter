using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public ControlPlayer playerControlScript;
    public WeaponFiringController[] weaponScript;
    public GameObject pauseMenu;



    private void Start()
    {
        Time.timeScale = 1;
        countWeapons();
        if(gameObject.tag == "Player")
        {
            pauseMenu = GameObject.Find("PausemenuContainer");
            pauseMenu.SetActive(false);
        }
        
    }

    private void Update()
    {
        
        if(Input.GetKey("escape") && pauseMenu != null) 
        {
              pauseMenu.SetActive(true);
              stopGame();
                                
        }
    }

    //locate the scripts that have to be stopped
    private void countWeapons()
    {
        
        weaponScript = new WeaponFiringController[gameObject.transform.childCount];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            weaponScript[i] = gameObject.transform.GetChild(i).GetComponent<WeaponFiringController>();

        }
    }


    //Stop game operation
    public void stopGame()
    {
        countWeapons();
        Cursor.visible = true;
        Time.timeScale = 0;

        playerControlScript.enabled = false;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            weaponScript[i].enabled = false;
        }
    }

    //Start game operation
    public void startGame()
    {
        countWeapons();
        
        //Cursor.visible = false;
        Time.timeScale = 1;

        playerControlScript.enabled = true;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            weaponScript[i].enabled = true;
        }
    }
}
