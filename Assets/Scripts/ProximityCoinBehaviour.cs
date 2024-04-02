using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCoinBehaviour : MonoBehaviour
{
    public static int value = 7;
    //public GameObject proximityCoinPrefab;

    // References to the AudioSource components for playing the sounds.

    [SerializeField] public AudioSource coinPickUp;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            // Generate a random position for each coin
            //Vector3 randomPosition = GeneratePosition();

            // Instantiate the coin at the random position
            //Instantiate(proximityCoinPrefab, randomPosition, Quaternion.Euler(90f, 0f, 0f));
        }

        for (int i = 0; i < 5; i++)
        {
            // Generate a random position for each coin
            //Vector3 randomPosition = GeneratePosition();

            // Instantiate the coin at the random position
            //Instantiate(proximityCoinPrefab, randomPosition, Quaternion.Euler(0f, 0f, 90f));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DemoPlayer"))
        {
            coinPickUp.Play();
            Destroy(gameObject);
        }
    }

    private Vector3 GeneratePosition()
    {
        System.Random random = new System.Random();

        float randomX = (float)random.Next(-8, 9);
        float randomZ = (float)random.Next(-8, 9);

        Vector3 randomPosition = new Vector3(randomX, 0.8F , randomZ);

        while (IsPositionOccupied(randomPosition))
        {
            randomX = (float)random.Next(-8, 9);
            randomZ = (float)random.Next(-8, 9);
            randomPosition = new Vector3(randomX, 0.8F, randomZ);
        }

        return randomPosition;
    }

    bool IsPositionOccupied(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
        return colliders.Length > 0;
    }

}
