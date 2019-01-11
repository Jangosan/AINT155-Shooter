using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMovingCheck : MonoBehaviour {

    //The animator of the game object
    private Animator moveAnim;

    //The rigidbody of the game object
    public Rigidbody2D objRgdBdy;

    private Vector2 oldPos;

    //Assign the animator and rigidbody
    void Start () {
        moveAnim = GetComponent<Animator>();
        objRgdBdy = GetComponent<Rigidbody2D>();
        oldPos = transform.position;
	}
	
	
    //If the rigidbody is moving then the isMoving parameter = true
	void Update () {

        if(objRgdBdy.position != oldPos)
        {
            moveAnim.SetBool("isMoving", true);
            oldPos = objRgdBdy.position;
        }
        else
        {
            moveAnim.SetBool("isMoving", false);
        }
	}
}
