using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    private Rigidbody2D body;
    public float speed;
    public float jumpForce = 5f;
    public bool isJumping;

    private Transform spriteRoot;

    // Audio
    public AudioClip[] jumpSounds;
    public AudioClip walkSound;

    private AudioSource walkSource;
    private AudioSource jumpSource;
    private bool isWalkingSoundPlaying;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRoot = GetComponentInChildren<SpriteRenderer>().transform;

        AudioSource[] sources = GetComponents<AudioSource>();
        walkSource = sources[0];
        jumpSource = sources[1];

        isJumping = false;
        isWalkingSoundPlaying = false;
    }

    private void Update()
    {
        float move = 0f;

        if (playerNumber == 1)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) move = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) move = 1f;

            if (!isJumping && Input.GetKeyDown(KeyCode.UpArrow)) Jump();
        }
        else if (playerNumber == 2)
        {
            if (Input.GetKey(KeyCode.A)) move = -1f;
            if (Input.GetKey(KeyCode.D)) move = 1f;
        }

        body.linearVelocity = new Vector2(move * speed, body.linearVelocity.y);

        // Face direction
        if (move != 0)
        {
            Vector3 scale = spriteRoot.localScale;
            scale.x = Mathf.Abs(scale.x) * (move > 0 ? 1 : -1);
            spriteRoot.localScale = scale;
        }

        // Walking sound (grounded only)
        if (Mathf.Abs(move) > 0.01f && !isJumping)
        {
            if (!isWalkingSoundPlaying)
            {
                walkSource.clip = walkSound;
                walkSource.loop = true;
                walkSource.Play();
                isWalkingSoundPlaying = true;
            }
        }
        else
        {
            if (isWalkingSoundPlaying)
            {
                walkSource.Stop();
                walkSource.loop = false;
                isWalkingSoundPlaying = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Square") ||
            collision.CompareTag("Box") || collision.CompareTag("Breakable") ||
            collision.CompareTag("PlatformA"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Square") ||
            collision.CompareTag("Box") || collision.CompareTag("Breakable") ||
            collision.CompareTag("PlatformA"))
        {
            isJumping = true;
        }
    }

    void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);

        if (jumpSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, jumpSounds.Length);
            jumpSource.PlayOneShot(jumpSounds[randomIndex]);
        }
    }
}
