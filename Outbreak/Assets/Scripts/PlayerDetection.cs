﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDetectionEvent : UnityEvent<Transform> { }

public class PlayerDetection : MonoBehaviour {

    public float losePlayerTime = 1.0f;

    //The layers for the raycast to interact with
    public LayerMask mask;

    //The parent gameObject of the gameObject this is attached to
    private GameObject parentCharacter;

    //The gameObject with the player tag
    private GameObject player;

    //Has the character already got a target
    public bool hasTarget = false;

    //The collider of the player
    private Collider2D playerCollider;

    //The event that is triggered when the player is detected
    public OnDetectionEvent onDetection;



    //Assigns the values for the two above variables
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        if(gameObject.transform.parent != null)
        {
            parentCharacter = gameObject.transform.parent.gameObject;
        }

        playerCollider = player.GetComponent<Collider2D>();


    }


    //If the character has a target, it will raycast towards the player to see if they are still visible. If not, a count down will begin, after which the player will be lost.
    private void Update()
    {
        
        //Raycast to see if player is still visible
        if (hasTarget == true)
        {

            RaycastHit2D findPlayer = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 5, mask);
            Debug.DrawRay(transform.position, player.transform.position - transform.position);
            if(findPlayer.collider != playerCollider)
            {
                
                hasTarget = false;
                StartCoroutine(loseTargetTimer());
            }
            
            


        }
    }

    //For use with spawners. When children get damaged the spawner sends a message to the children to target the player
    public void assignTargetForChildren()
    {
        Invoke("loopChildTargetAssign", 0);
    }

    private void loopChildTargetAssign()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == "Enemy")
            {
                

                gameObject.transform.GetChild(i).SendMessage("SetTarget", player.transform);

            }

        }
    }

    private void OnTriggerStay2D(Collider2D target)
    {

        rayCastDetect(target);
    }


    //Once triggered, will raycast towards the player and if there is nothing blocking the raycast, the target will be assigned;
    private void rayCastDetect(Collider2D target)
    {
        //If the character doesn't have a target and has a parent character
        if (hasTarget == false && parentCharacter != null)
        {
            //if the target transform is the player transform 
            if (target.transform == player.transform)
            {   
                //cast a ray in the direction of the player and if it collides with the player set the target to the player
                RaycastHit2D findPlayer = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 5, mask);
                Debug.DrawRay(transform.position, player.transform.position - transform.position);
                if (findPlayer.collider == playerCollider)
                {                   
                    onDetection.Invoke(player.transform);
                    hasTarget = true;
                    
                }

            }
        }
    }
    //When the collider is entered, if the target is the player, the script sends a message to the parent to run the AssignTarget method with the player as the target
    private void OnTriggerEnter2D(Collider2D target)
    {

        rayCastDetect(target);
    }


    //Enemies can alert other enemies if they can see this one
    private void OnTriggerExit2D(Collider2D target)
    {
        
        if (target.transform.tag == "Enemy" && hasTarget == true)
        {
            onDetection.Invoke(player.transform);
        }

    }

    

    IEnumerator loseTargetTimer()
    {
        
        yield return new WaitForSeconds(losePlayerTime);
        if (!hasTarget)
        {

            onDetection.Invoke(null);
        }
    }
    //For event dependent target assigning instead of based off the detection range
    public void assignTargetOnEvent()
    {
        onDetection.Invoke(player.transform);
        hasTarget = true;
    }


    
}
