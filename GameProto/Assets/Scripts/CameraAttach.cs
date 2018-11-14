using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour {

    //Variable to hold the target of the camera
    public Transform cameraTarget;

    //Used to smooth the movement of the camera
    public float cameraSmooth = 40.0f;

    // Use this for initialization
    void Start () {
        
	}
	

    private void Update()
    {
        Vector3 currentPos = transform.position;
       
        Vector3 targetPos = cameraTarget.position;

        Vector3 newPos;

        newPos.y = targetPos.y;
        newPos.x = targetPos.x;
        newPos.z = -5;
        float moveSpeed = cameraSmooth * 0.001f;
        transform.position = Vector3.Lerp(currentPos, newPos, moveSpeed);
    }
}
