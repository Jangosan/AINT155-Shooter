using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerUpdate : MonoBehaviour {

    public UnityEvent OnSpawnEnemy;

    //The maximum number of enemies to spawn
    public int maxToSpawn;

    //The total number of spawned that are currently in-game
    private int totalPrefabs;

    //The number of enemies spawned each time
    public int numberToSpawn;

    //The interval between spawns
    public float spawnDelay;

    //Used to adjust the angle that enemies are spawned at if the art requires it
    public float adjustmentAngle = 0;

    //The prefab of the enemy being spawned
    public GameObject prefabToSpawn;

    //The maximum distance that enemies can be spawned from the spawner (enemies created are randomly positioned within this area)
    public float maxSpawnDist;
    

    /*When this event is triggered, the spawnPrefab method is invoked once per numberToSpawn (for exampele, if numberToSpawn is 2 the method will invoke twice)
    the method is invoked instantly the first time and then at repeating intervals, the length of which is determined by the spawnDelay variable*/
    private void beginSpawn()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            InvokeRepeating("spawnPrefab", 0, spawnDelay);
        }

    }
    //gets the totalPrefabs value based off the number of children the spawner has
    private void Update()
    {
        totalPrefabs = transform.childCount;
    }

    /*Instantiate the prefab at a random position within the maxSpawnDist with the adjustmentAngle applied to rotation.
    Won't do anything if the number of spawned enemies is greater than or equal to the max*/
    private void spawnPrefab() {
        
        Vector3 spawnPosition;

        spawnPosition.x = transform.position.x + Random.Range(-maxSpawnDist, maxSpawnDist);
        spawnPosition.y = transform.position.y + Random.Range(-maxSpawnDist, maxSpawnDist);
        spawnPosition.z = 0;

        Vector3 rotationInDegrees = transform.eulerAngles;

        rotationInDegrees.z += adjustmentAngle;

        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);

        if (totalPrefabs < maxToSpawn)
        {
            OnSpawnEnemy.Invoke();
            Instantiate(prefabToSpawn, spawnPosition, rotationInRadians, transform);
        }
        
    }
}
