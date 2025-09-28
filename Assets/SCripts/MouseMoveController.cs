using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MouseMoveController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 85f;

    private CharacterController controller;
    private Transform playerCamera;
    private float verticalLookRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Automatically find child camera
        playerCamera = GetComponentInChildren<Camera>()?.transform;

        if (playerCamera == null)
        {
            Debug.LogError("No camera found as child of Player.");
        }

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();

        // Unlock cursor with Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Horizontal look (player body)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical look (camera)
        if (playerCamera != null)
        {
            verticalLookRotation -= mouseY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -maxLookAngle, maxLookAngle);
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

