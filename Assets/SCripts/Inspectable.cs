using UnityEngine;
using UnityEngine.InputSystem;

public class Inspectable : MonoBehaviour
{
    public GameObject inspectionUI;          // assign your UI panel here
    public InputActionAsset inputActions;    // assign PlayerControls asset here

    private InputAction closeAction;

    public void Inspect()
    {
        if (inspectionUI != null)
        {
            inspectionUI.SetActive(true);
        }

        if (inputActions != null && closeAction == null)
        {
            var gameplayMap = inputActions.FindActionMap("Gameplay");
            closeAction = gameplayMap.FindAction("Close"); // Escape binding
            if (closeAction != null)
            {
                closeAction.Enable();
                closeAction.performed += ctx => CloseInspection();
            }
        }
    }

    public void CloseInspection()
    {
        if (inspectionUI != null)
        {
            inspectionUI.SetActive(false);
        }

        if (closeAction != null)
        {
            closeAction.performed -= ctx => CloseInspection();
            closeAction.Disable();
            closeAction = null; // reset for next inspect
        }
    }
}