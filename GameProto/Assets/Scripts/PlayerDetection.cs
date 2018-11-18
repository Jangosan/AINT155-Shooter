using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {

    //The parent gameObject of the gameObject this is attached to
    private GameObject parentCharacter;

    //The gameObject with the player tag
    private GameObject player;

    //Has the character already got a target
    private bool hasTarget = false;

    //Assigns the values for the two above variables
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        if(gameObject.transform.parent != null)
        {
            parentCharacter = gameObject.transform.parent.gameObject;
        }
        

    }

    //When the collider is entered, if the target is the player, the script sends a message to the parent to run the AssignTarget method with the player as the target
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (hasTarget == false && parentCharacter != null)
        {
            if (target.transform == player.transform)
            {
                parentCharacter.SendMessage("AssignTarget", target.transform, SendMessageOptions.DontRequireReceiver);
                hasTarget = true;
            }
        }
           
    }

    //Enemies can alert other enemies if they can see this one
    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.transform.tag == "Enemy" && hasTarget == true)
        {
            target.SendMessage("AssignTarget", player.transform, SendMessageOptions.DontRequireReceiver);
        }
    }


    //For event dependent target assigning instead of based off the detection range
    public void assignTargetOnEvent()
    {      
        gameObject.SendMessage("AssignTarget", player.transform, SendMessageOptions.DontRequireReceiver);
        hasTarget = true;
    }


    //For use with spawners. When children get damaged the spawner sends a message to the children to target the player
    public void assignTargetForChildren()
    {
        InvokeRepeating("loopChildTargetAssign", 0, Time.deltaTime);
    }

    private void loopChildTargetAssign()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == "Enemy")
            {
                print(gameObject.transform.GetChild(i).name);
                gameObject.transform.GetChild(i).SendMessage("AssignTarget", player.transform);
                hasTarget = true;
            }

        }
    }
}
