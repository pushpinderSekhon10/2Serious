using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCoinBehaviour : MonoBehaviour
{
    public static int value = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DemoPlayer")) {
            Destroy(gameObject);
        }
    }
}
