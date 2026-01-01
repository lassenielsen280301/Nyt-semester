using UnityEngine;

public class ToggleSpriteOnCircleTrigger : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;

    [Header("Sounds")]
    public AudioClip enterSound;
    public AudioClip exitSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        // Auto-find SpriteRenderer if not assigned
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
        {
            // Turn sprite OFF
            spriteRenderer.enabled = false;

            // Play enter sound
            if (enterSound != null)
            {
                audioSource.PlayOneShot(enterSound);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
        {
            // Turn sprite ON
            spriteRenderer.enabled = true;

            // Play exit sound
            if (exitSound != null)
            {
                audioSource.PlayOneShot(exitSound);
            }
        }
    }
}

