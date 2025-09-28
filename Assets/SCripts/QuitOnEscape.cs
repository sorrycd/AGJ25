using UnityEngine;

public class QuitOnEscape : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed, quitting game...");
            Application.Quit();

            // If running in the editor, stop play mode
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
