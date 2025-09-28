using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathCutscenePlayer : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "MainMenu"; // Set in Inspector

    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}