
using UnityEngine;
 
public class SmoothFollow2D : MonoBehaviour
{

    //the target of the script
    public Transform target;

    //the rigidbody of the character this script is attached to
    public Rigidbody2D character;

    //the movement speed
    public float moveSpeed = 5.0f;

    //
    public float rotSmoothing = 5.0f;

    public float adjustmentAngle = 0.0f;

    //get the rigidbody of the gameobject
    private void Start()
    {
        character = gameObject.GetComponent<Rigidbody2D>();

    }

    //on each update the transform will move and rotate towards the target
    void Update()
    {
        if (target != null)
        {
            Vector3 difference = target.position - transform.position;

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));

            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * rotSmoothing);


            character.velocity -= (Vector2)transform.up * Time.deltaTime * moveSpeed;






            print(target);
        }
    }
    
    //sets the target for the gameobject to follow
    public void AssignTarget(Transform targetTrans)
    {
        target = targetTrans;
        print("Target for " + gameObject.name + " should be assigned");
    }

    public void UnassignTarget()
    {
        Transform blankTransform = null;
        target = blankTransform;
        print("Target for " + gameObject.name + " should be unassigned" + "(" + target);
    }
}
