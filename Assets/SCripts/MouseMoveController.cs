using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MouseMoveController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;
    public Transform playerCamera;
    public float maxLookAngle = 85f;

    private CharacterController controller;
    private float verticalLookRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerCamera == null)
        {
            Debug.LogError("Assign the camera Transform to the 'Player Camera' field in the inspector.");
        }
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera (pitch)
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -maxLookAngle, maxLookAngle);

        if (playerCamera != null)
        {
            playerCamera.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
        }
    }

    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetMouseButton(0)) // LMB - Forward
        {
            moveDirection += transform.forward;
        }

        if (Input.GetMouseButton(1)) // RMB - Backward
        {
            moveDirection -= transform.forward;
        }

        moveDirection = moveDirection.normalized * moveSpeed;
        controller.SimpleMove(moveDirection);
    }
}
