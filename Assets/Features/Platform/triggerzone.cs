using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    [Header("Activation Settings")]
    public string targetPlatformTag = "PlatformA";
    public KeyCode activateKey = KeyCode.LeftShift;

    [Header("Visual Feedback")]
    public SpriteRenderer buttonSprite;      // Button sprite
    public Color normalColor = Color.white;  // Default color
    public Color glowColor = new Color(1f, 1f, 1f, 1.3f); // Slight glow
    public GameObject pressText;              // "Press L-Shift" text

    private bool playerInside = false;

    private void Start()
    {
        // Make sure visuals start off
        if (buttonSprite != null)
            buttonSprite.color = normalColor;

        if (pressText != null)
            pressText.SetActive(false);
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(activateKey))
        {
            GameObject[] platforms = GameObject.FindGameObjectsWithTag(targetPlatformTag);

            foreach (GameObject platformObj in platforms)
            {
                MovingPlatform platform = platformObj.GetComponent<MovingPlatform>();
                if (platform != null)
                {
                    platform.Activate();
                    Debug.Log($"Activated platform with tag {targetPlatformTag}");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
        {
            playerInside = true;

            // Light up button
            if (buttonSprite != null)
                buttonSprite.color = glowColor;

            // Show text
            if (pressText != null)
                pressText.SetActive(true);

            Debug.Log($"Player entered button zone. Press {activateKey} to activate {targetPlatformTag}.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
        {
            playerInside = false;

            // Reset button color
            if (buttonSprite != null)
                buttonSprite.color = normalColor;

            // Hide text
            if (pressText != null)
                pressText.SetActive(false);

            Debug.Log("Player left the button zone.");
        }
    }
}


