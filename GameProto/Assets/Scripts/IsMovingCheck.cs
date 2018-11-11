using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMovingCheck : MonoBehaviour {

    private Animator moveAnim;
    public Rigidbody2D objRgdBdy;
    public Vector2 velocity;

 
	
	void Start () {
        moveAnim = GetComponent<Animator>();
        objRgdBdy = GetComponent<Rigidbody2D>();
        
	}
	
	
	void Update () {
        velocity = objRgdBdy.velocity;
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
