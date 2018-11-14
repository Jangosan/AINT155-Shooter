using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float spawnInterval = 0;
    
    public float adjustmentAngle = 0;
    

    private void Start()
    {
        
    }

    public void spawn() {
       if (spawnInterval == 0)
        {
            instantiateObject();
        }
        else
        {
            Invoke("instantiateObject", spawnInterval);
        }

        
	}
	
	public void instantiateObject()
    {
        Vector3 rotationInDegrees = transform.eulerAngles;
        rotationInDegrees.z += adjustmentAngle;

        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
        
        Instantiate(prefabToSpawn, transform.position, rotationInRadians);
    }
}
