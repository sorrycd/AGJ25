using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public GameObject inspectionUI; // assign the note panel here

    public void Inspect()
    {
        if (inspectionUI != null)
            inspectionUI.SetActive(true);
    }

    public void CloseInspection()
    {
        if (inspectionUI != null)
            inspectionUI.SetActive(false);
    }
}
