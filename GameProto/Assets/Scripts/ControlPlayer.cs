using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour {

    //GLOBAL VARIABLES//

    //The multiplier for the total speed of the character
    public float movementSpeed = 1;

    //store the input in a variable
    private Vector2 input;

    //The total movement velocity of the character
    public Vector2 moveVelocity;

    //Store the rigidbody component in a variable
    Rigidbody2D player;


    public Vector2 mousePos;
    //PROCEDURES//

	// Use this for initialization
	void Start () {
        
        //Identify the rigidbody component to be stored
        player = gameObject.GetComponent<Rigidbody2D>();     
        
	}
	
	// Update is called once per frame
	void Update () {        

        //Creates a vector based off the inputs
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //set the movement velocity to the input amount * the movement speed
        moveVelocity = Vector3.Normalize(input) * movementSpeed;

        
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;


        //find the distance from the mouse position to the position of the camera in the screen
        Vector3 distance = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        //calculate the arc tangent of x and y of the distance and convert to degrees 
        float angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg;

        //rotate the character to the angle determined by the previous step
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);

        //stop movement if there is no input
        if (Input.GetAxisRaw("Horizontal") == 0 & Input.GetAxisRaw("Vertical") == 0)
        {
            player.isKinematic = true;
        }
        else
        {
            player.isKinematic = false;
        }

        //set player velocity to the the input value * the movement speed
        player.velocity = moveVelocity;

    }

}
