using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public InputActionAsset inputActions; 
    private InputAction moveAction;
    private Vector2 currentMovementInput;

    private void Awake()
    {
        // Initialize the move action
        var playerControls = inputActions.FindActionMap("player");
        moveAction = playerControls.FindAction("move");

        // Capture the movement input
        moveAction.performed += ctx => currentMovementInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => currentMovementInput = Vector2.zero;
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        // Apply the movement input to the character's position
        Vector3 movement = new Vector3(currentMovementInput.x, 0, currentMovementInput.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
