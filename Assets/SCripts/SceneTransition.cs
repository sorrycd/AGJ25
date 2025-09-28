using UnityEngine;
using UnityEngine.SceneManagement; // <-- this is the line I meant

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Set this in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Only triggers if the player enters
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}