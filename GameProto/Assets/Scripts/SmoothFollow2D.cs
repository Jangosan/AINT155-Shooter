
using UnityEngine;
 
public class SmoothFollow2D : MonoBehaviour
{

    public Transform target;

    public Rigidbody2D character;

    public float moveSpeed = 5.0f;

    public float rotSmoothing = 5.0f;

    public float adjustmentAngle = 0.0f;

    public Vector2 debugVelocity;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        character = gameObject.GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 difference = target.position - transform.position;

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));

            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * rotSmoothing);


            character.velocity -= (Vector2)transform.up * Time.deltaTime * moveSpeed;

           

            debugVelocity = character.velocity;
           
 

        }
    }
}
