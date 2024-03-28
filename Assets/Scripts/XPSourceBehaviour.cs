using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSourceBehaviour : MonoBehaviour
{
    public static int value = 100;
    public GameObject keyPrefab;

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
        if (other.CompareTag("DemoPlayer"))
        {
            Vector3 xpPosition = this.transform.position;
            Vector3 keyPosition = new Vector3(xpPosition.x, xpPosition.y, xpPosition.z + 2);

            Destroy(gameObject);
            Instantiate(keyPrefab, keyPosition, Quaternion.identity);
        }
    }

}
