using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;

    Vector3 moveInput;

    public float moveSpeed = 0.005f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveInput.z = Input.GetAxis("Vertical") * moveSpeed;

        controller.Move(moveInput);
    }
}
