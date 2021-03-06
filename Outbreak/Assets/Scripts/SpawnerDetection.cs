﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDetection : MonoBehaviour {

    //The gameObject with the player tag
    private GameObject player;

    public Transform[] spawnerList;

    private bool active = false;


    //Assigns the values for the two above variables
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {               
            active = false;                
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform == player.transform)
        {   
            if (spawnerList.Length != 0)
                for (int i = 0; i < spawnerList.Length; i++)
                {
                    if (spawnerList[i] != null)
                    {
                        if (!active)
                        {
                            spawnerList[i].SendMessage("beginSpawn", SendMessageOptions.DontRequireReceiver);
                        }
                        
                        spawnerList[i].SendMessage("assignTargetForChildren", player, SendMessageOptions.DontRequireReceiver);
                    }

                    
                }
            active = true;
        }
    }
}
