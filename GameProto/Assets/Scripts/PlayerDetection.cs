using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {

    //The parent gameObject of the gameObject this is attached to
    private GameObject parentCharacter;

    //The gameObject with the player tag
    private GameObject player;

    //Assigns the values for the two above variables
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        parentCharacter = gameObject.transform.parent.gameObject;

    }

    //When the collider is entered, if the target is the player, the script sends a message to the parent to run the AssignTarget method with the player as the target
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform == player.transform)
        {         
            parentCharacter.SendMessage("AssignTarget", target.transform, SendMessageOptions.DontRequireReceiver);
        }
    }
}
