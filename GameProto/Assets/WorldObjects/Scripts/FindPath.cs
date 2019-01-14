using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FindPath : MonoBehaviour {
       
    private IAstarAI ai;

    private Transform destination;

	
	void Start () {
        ai = GetComponent<IAstarAI>();
	}
	
	//set the target to the position of the destination each frame
	void Update () {
        if (destination != null && ai != null)
        {
            ai.destination = destination.position;
            ai.SearchPath();


        }
    }

    //set the destination to the target if the player has been detected in the detection script
    public void SetTarget(Transform target)
    {
        destination = target;

    }
}
