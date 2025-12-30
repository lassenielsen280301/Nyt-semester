using UnityEngine;

public class CharacterDeathSound : MonoBehaviour
{
    [SerializeField] private AudioClip deathClip;

    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Awake()
    {
        // Gør objektet persistent mellem scene loads
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.volume = 1f;
        audioSource.mute = false;
        audioSource.spatialBlend = 0f; // 2D lyd

        if (deathClip == null)
            Debug.LogError("DeathClip mangler på " + gameObject.name);
    }

    public void PlayDeathSound()
    {
        if (hasPlayed) return;
        if (deathClip == null) return;

        audioSource.PlayOneShot(deathClip);
        hasPlayed = true;
    }

    public float DeathClipLength
    {
        get
        {
            return deathClip != null ? deathClip.length : 1f;
        }
    }

    // Kaldes hvis scenen reloader igen
    private void OnLevelWasLoaded(int level)
    {
        hasPlayed = false;
    }
}

