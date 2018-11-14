using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUpdate : MonoBehaviour {

    public int maxToSpawn;
    private int totalPrefabs;
    public int numberToSpawn;
    public float spawnDelay;
    public float adjustmentAngle = 0;
    public GameObject prefabToSpawn;
    public float maxSpawnDist;
    
    public Vector3 spawnPosition;





    // Use this for initialization
    void Start() {
        
        for (int i = 0; i < numberToSpawn; i++)
        {
            InvokeRepeating("spawnPrefab", 0, spawnDelay);
        }
        
	}

    private void Update()
    {
        totalPrefabs = transform.childCount;
    }

    private void spawnPrefab() {

        

        spawnPosition.x = transform.position.x + Random.Range(-maxSpawnDist, maxSpawnDist);
        spawnPosition.y = transform.position.y + Random.Range(-maxSpawnDist, maxSpawnDist);
        spawnPosition.z = 0;

        Vector3 rotationInDegrees = transform.eulerAngles;

        rotationInDegrees.z += adjustmentAngle;

        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);

        if (totalPrefabs < maxToSpawn)
        {
            Instantiate(prefabToSpawn, spawnPosition, rotationInRadians, transform);
        }
        
    }
}
