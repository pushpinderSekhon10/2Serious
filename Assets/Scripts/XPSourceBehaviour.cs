using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSourceBehaviour : MonoBehaviour
{
    public static int value = 10;

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
        if (collision.gameObject.name == "DemoPlayer") {
            Destroy(gameObject);
        }
    }
}
