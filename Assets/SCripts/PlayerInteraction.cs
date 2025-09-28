using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5f;
    public LayerMask interactLayer;
    public InputActionAsset inputActions; // assign PlayerControls asset here

    private InputAction interactAction;

    private void OnEnable()
    {
        if (inputActions == null) return;

        var gameplayMap = inputActions.FindActionMap("Player");
        interactAction = gameplayMap.FindAction("Interact");
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
        Debug.Log("Interact called.");
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * interactRange, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, interactRange, interactLayer))
        {
            Inspectable inspectable = hit.collider.GetComponent<Inspectable>();
            if (inspectable != null)
            {
                inspectable.Inspect();
            }
        }
    }
}