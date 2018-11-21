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
    private Vector2 moveVelocity;

    //Store the rigidbody component in a variable
    public Rigidbody2D player;

    //the two dimensional position of the mouse
    public Vector2 mousePos;

    public float rotationSmoothing = 40.0f;

    public float adjustmentAngle = 90;

    //PROCEDURES//

	// Use this for initialization
	void Start () {

        Cursor.visible = false;
        //Identify the rigidbody component to be stored
        player = gameObject.GetComponent<Rigidbody2D>();     
        
	}
	
	//Based off framerate for smoother animation of the player
	void FixedUpdate () {        

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





        float rotationSpeed = Time.deltaTime * rotationSmoothing;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;



        float angleZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        Vector3 rotationInDegrees = new Vector3();

        /*
         * SET THE X AND Y TO ZERO
         * We don't want to rotate our GameObject on X and Y, so we set them to zero
         */
        rotationInDegrees.x = 0;
        rotationInDegrees.y = 0;

        /*
         * SET THE Z ANGLE TO OUR NEW ANGLE AND ADD IN OUR ADJUSTMENT
         * here we set the Z angle to our new "angleZ" and add our pulic variable "adjustmentAngle"
         * this means we can set the correct facing angle in the editor!
         */
        rotationInDegrees.z = angleZ + adjustmentAngle;

        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);


        //rotate the character to the angle determined by the previous step
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationInRadians, rotationSpeed);
        
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
