using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCoinBehaviour : MonoBehaviour
{
    public static int value = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DemoPlayer")
        {
            Debug.Log("Collision between collisionCoin and Player");
            Destroy(gameObject);
        }
    }
}
