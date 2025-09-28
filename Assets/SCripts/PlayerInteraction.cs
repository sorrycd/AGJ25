using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5f;
    public LayerMask interactLayer;
    public InputAction interactAction; // assign Interact action (E) in inspector

    private Inspectable currentInspectable;
    private bool isInspecting = false;

    private void OnEnable()
    {
        if (interactAction != null)
        {
            interactAction.Enable();
            interactAction.performed += ctx => Interact();
        }
    }

    private void OnDisable()
    {
        if (interactAction != null)
        {
            interactAction.performed -= ctx => Interact();
            interactAction.Disable();
        }
    }

    private void Interact()
    {
        if (isInspecting && currentInspectable != null)
        {
            // Close current note
            currentInspectable.CloseInspection();
            isInspecting = false;
            EnablePlayerMovement(true);
            currentInspectable = null;
            return;
        }

        // Raycast to see if a note is in front
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
        {
            Inspectable inspectable = hit.collider.GetComponent<Inspectable>();
            if (inspectable != null)
            {
                currentInspectable = inspectable;
                currentInspectable.Inspect();
                isInspecting = true;
                EnablePlayerMovement(false);
            }
        }
    }

    private void EnablePlayerMovement(bool enable)
    {
        var controller = GetComponentInParent<MouseMoveController>();
        if (controller != null)
            controller.enabled = enable;
    }
}
