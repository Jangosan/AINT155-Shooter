using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerScript : MonoBehaviour {

    private LineRenderer laserOrigin;
    public Transform laserEnd;
	// Use this for initialization
	void Start () {
        laserOrigin = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        RaycastHit2D hitPoint = Physics2D.Raycast(transform.position, transform.parent.transform.up);
        Debug.DrawLine(transform.position, hitPoint.point);
        laserEnd.position = hitPoint.point;

        laserOrigin.SetPosition(0, transform.position);
        laserOrigin.SetPosition(1, laserEnd.position);
        
	}
}
