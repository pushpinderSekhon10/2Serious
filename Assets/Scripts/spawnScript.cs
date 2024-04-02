using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to be spawned
    public float spawnRadius = 5f;
    [SerializeField] public Vector3 spawnPosition = new Vector3(1141, 80, 763);
    void Start()
    {
        // Start spawning enemies at intervals
        SpawnEnemy();
    }

    void SpawnEnemy()
    {

        // Generate a random position within the spawn radius
        //Vector3 spawnPosition = new Vector3(1021, 85, 688);

        // Instantiate the enemy at the random position
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);


    }

    // Call this method when an enemy is destroyed to decrement the current enemy count

    
}
