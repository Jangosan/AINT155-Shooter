using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLaser : MonoBehaviour {


    private LineRenderer laserSpawn;
    public Transform hitPoint;
    public Transform player;

	// Use this for initialization
	void Start ()
    {
        laserSpawn = GetComponent<LineRenderer>();     
        laserSpawn.useWorldSpace = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 raycastDir = hitPoint.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, hitPoint.position, Mathf.Infinity);
        Debug.DrawLine(transform.position, hitPoint.position);
        
        hitPoint.position = hit.transform.position;
	}
}
