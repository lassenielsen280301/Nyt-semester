using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitAudioPlayer : MonoBehaviour
{
    public static ExitAudioPlayer Instance;
    public AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayExitSound()
    {
        audioSource.Play();
    }
}
