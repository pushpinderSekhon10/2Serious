using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{

    public float speed = 0.25f;
    private float angle = 0;
    public GameObject directLight;

    void ChangeAngle()
    {
        angle += speed;
        Quaternion rot = Quaternion.Euler(angle, 100, 0);
        directLight.transform.rotation = rot;
    }

    private void FixedUpdate()
    {
        ChangeAngle();
    }
}
