using UnityEngine;

public class Example : ResourceManager
{
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float rotSpeed;

    [SerializeField]
    private float jSpeed;

    [SerializeField]
    private float gracePeriod;

    [SerializeField]
    private Transform cameraTransform;

    private CharacterController characterController;
    private float ySpeed;
    private float stepOffset;
    private float? previousGroundedTime;
    private float? jumpButtonPressedTime;


    // Start is called before the first frame update
    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        stepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        float inputMag = Mathf.Clamp01(move.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMag /= 2;
        }

        

        float speed = inputMag * 10;
        move = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * move;
        move.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            previousGroundedTime = Time.time;
        }


        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - previousGroundedTime <= gracePeriod)
        {
            characterController.stepOffset = stepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= gracePeriod)
            {
                ySpeed = jSpeed;
                jumpButtonPressedTime = null;
                previousGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = move * speed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
        }
        Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
