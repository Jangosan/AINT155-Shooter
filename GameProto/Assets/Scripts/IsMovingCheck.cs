using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMovingCheck : MonoBehaviour {

    //The animator of the game object
    private Animator moveAnim;

    //The rigidbody of the game object
    public Rigidbody2D objRgdBdy;

	//Assign the animator and rigidbody
	void Start () {
        moveAnim = GetComponent<Animator>();
        objRgdBdy = GetComponent<Rigidbody2D>();        
	}
	
	
    //If the rigidbody is moving then the isMoving parameter = true
	void Update () {
        
		if(objRgdBdy.velocity.magnitude > 0)
        {
            moveAnim.SetBool("isMoving", true);
        }
        else
        {
            moveAnim.SetBool("isMoving", false);
        }
	}
}
