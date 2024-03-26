using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCoinBehaviour : MonoBehaviour
{
    public static int value = 7;

    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = GeneratePosition();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DemoPlayer"))
        {
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
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        return colliders.Length > 0;
    }

}
