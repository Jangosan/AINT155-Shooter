/*******************************************************
 * 
 * SmoothFollow2D.cs
 *  - follows the transform of another GameObject
 *  - uses a smoothing variable to animate movement over time
 * 
 * 
 * 
 * public variables:
 *  - target
 *    - the transform of the GameObject to follow
 *    
 *  - smoothing
 *    - the speed of movement towards the target transform
 *    
 *    
 * private variables: none
 *    
 *    
 * Monobehaviour methods
 *  - FixedUpdate
 *    - runs contantly at a fixed time step
 *    - only runs while this script is active
 *    - see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
 * 
 * 
 *******************************************************/
using UnityEngine;
 
public class SmoothFollow2D : MonoBehaviour
{
    /*********************
     * 
     * PUBLIC VARIABLES
     * A "public" variable is declared outside of any methods.
     * We can change these in the editor without changing any of the code.
     * 
     *********************/

    /*
     * target
     * this is the Transform component belonging to the GameObject we want to follow
     * set this variable in the editor by dragging the other GameObject onto this variable in the editor
     * see link: https://docs.unity3d.com/ScriptReference/Transform.html
     */
    public Transform target;


    /*
     * smoothing
     * smoothing is a float (a decimal number) to set how fast we move towards the target.
     * smoothing has a default setting of "5.0f", this setting can be changed in the editor!
     * NOTE: ALL float number values MUST end with an "f"
     */
    public float smoothing = 5.0f;


    /*
    * FixedUpdate
    * A method (also known as an "Event Function") provided by Monobehaviour that will run at a fixed time step.
    * FixedUpdate is most useful for the Physics system, such adding a force or velocity to a Rigidbody2D.
    * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    * 
    * In this method we will get the position of this GameObject and the position of the target GameObject.
    * Then we will use "Vector3.Lerp" to move towards the target GameObject over time
    * "Lerp" is short for "Linear Interpolation"
    * see link: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
    * 
    * NOTE: we are using FixedUpdate because we will be "following" a Rigidbody2D, and it will look smoother if we 
    *       use the same "update" method for both!
    */
    void FixedUpdate()
    {
        /*
         * GET THIS GAMEOBJECT'S CURRENT POSITION
         * we can get our current position from the Transform component using "transform.position"
         * see link: https://docs.unity3d.com/ScriptReference/Transform-position.html
         * "transform.position" is a Vector3, which has 3 properties: X, Y and Z.
         * see link: https://docs.unity3d.com/ScriptReference/Vector3.html
         * we create a Vector3 variable to store our transform's current position
         */
        Vector3 currentPosition = transform.position;


        /*
         * GET THE target GAMEOBJECT'S CURRENT POSITION
         * the public variable, "target" is a Transform, so we can get its position by using
         * "target.position", which will give us a Vector3
         * we create a Vector3 variable to store our target's current position
         */
        Vector3 targetPosition = target.position;


        /*
         * SET OUR SMOOTHING TO A LOWER VALUE
         * we need to reduce the size of the public variable "smoothing".
         * If we don't, the speed will be instantaneous! (it's to do with the size of a "unit" in Unity)
         * if we multiply smoothing by a very small number (or divide by a large number), it will give us a very small number to animate with
         * we create a variable from multiplying smoothing by 0.001 (one thousandth!)
         */ 
        float moveSpeed = smoothing * 0.001f;


        /*
         * CREATE A Vector3 VARIABLE FOR OUR NEW POSITION
         * We only want the X and Y position of the target, and keep our original Z position.
         * This is becuase this script is meant for Camera movement.
         * If the Camera's Z position is the same as the target's Z position, we wont be able to see it! the camera will "zoom" in too far!
         */ 
        Vector3 newPosition = new Vector3();


        /*
         * SET POSITION X TO THE TARGET X
         * We want to move to the target X position
         */ 
        newPosition.x = targetPosition.x;


        /*
         * SET POSITION Y TO THE TARGET Y
         * We want to move to the target Y position
         */ 
        newPosition.y = targetPosition.y;


        /*
         * SET THE POSITION Z TO OUR TRANSFORM POSITION Z
         * We want to keep our original Z position to keep the camera's distance away from the target
         */ 
        newPosition.z = currentPosition.z;


        /*
         * USE "LERP" TO MOVE TO THE NEW POSITION
         * "Lerp" is short for "Linear Interpolation" - or movement over time!
         * we set our current position (transform.position) to move a little bit towards the target position every update
         * see link: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
         * we give Vector3.Lerp our current position (currentPosition), the new position (newPosition) and a speed to move by (moveSpeed)
         */
        transform.position = Vector3.Lerp(currentPosition, newPosition, moveSpeed);
    }
}
