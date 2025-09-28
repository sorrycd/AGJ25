using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bashClip;
    public AudioClip shootClip;
    public AudioClip stabClip;

    public void PlayBash(){
        audioSource.PlayOneShot(bashClip);
    }
    public void PlayShoot(){
        audioSource.PlayOneShot(shootClip);
    }
    public void PlayStab(){
        audioSource.PlayOneShot(stabClip);
    }
}