using UnityEngine;

public class PlaySoundOnPush : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody2D rb;

    public float minVelocity = 0.1f;
    public float delayBeforeSound = 2f;
    public float maxVolume = 1f;
    public float fadeSpeed = 5f;

    private bool canPlaySound = false;
    private bool playerIsPushing = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        audioSource.volume = 0f;
        audioSource.loop = true;

        Invoke(nameof(EnableSound), delayBeforeSound);
    }

    void EnableSound()
    {
        canPlaySound = true;
    }

    void Update()
    {
        if (!canPlaySound) return;

        float speed = rb.linearVelocity.magnitude;

        float targetVolume =
            (playerIsPushing && speed > minVelocity) ? maxVolume : 0f;

        audioSource.volume = Mathf.Lerp(
            audioSource.volume,
            targetVolume,
            Time.deltaTime * fadeSpeed
        );

        if (targetVolume > 0f && !audioSource.isPlaying)
            audioSource.Play();

        if (audioSource.volume < 0.01f && audioSource.isPlaying)
            audioSource.Stop();
    }

    // Når spilleren begynder at skubbe
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canPlaySound) return;

        if (collision.gameObject.CompareTag("Square"))
        {
            playerIsPushing = true;
        }
    }

    // Mens spilleren bliver ved med at skubbe
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            playerIsPushing = true;
        }
    }

    // Når spilleren stopper med at skubbe
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            playerIsPushing = false;
        }
    }
}


