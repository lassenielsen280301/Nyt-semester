using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxSpawnerButton : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject boxPrefab;
    public Transform spawnPoint;

    [Header("Button Settings")]
    public Animator buttonAnimator;
    public string pressTrigger = "Press";

    [Header("Box Limit")]
    public int maxBoxes = 4;

    [Header("Box Physics")]
    public float gravityScale = 1f;
    public float dropSpeed = 1f;

    [Header("Visual Feedback")]
    public SpriteRenderer buttonSprite;
    public Color normalColor = Color.white;
    public Color glowColor = new Color(1f, 1f, 1f, 1.3f);
    public GameObject pressText; // "Press E" text popup

    private bool playerInside = false;
    private bool isAnimating = false;
    private List<GameObject> spawnedBoxes = new List<GameObject>();

    void Start()
    {
        if (buttonSprite != null)
            buttonSprite.color = normalColor;

        if (pressText != null)
            pressText.SetActive(false);
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E) && !isAnimating)
        {
            StartCoroutine(PressButtonRoutine());
        }
    }

    private IEnumerator PressButtonRoutine()
    {
        isAnimating = true;

        if (buttonAnimator != null && !string.IsNullOrEmpty(pressTrigger))
        {
            buttonAnimator.SetTrigger(pressTrigger);
        }

        yield return new WaitForSeconds(0.1f);

        if (boxPrefab != null && spawnPoint != null)
        {
            GameObject newBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);

            Rigidbody2D rb = newBox.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = gravityScale;
                rb.linearVelocity = Vector2.down * dropSpeed;
            }

            spawnedBoxes.Add(newBox);

            if (spawnedBoxes.Count > maxBoxes)
            {
                Destroy(spawnedBoxes[0]);
                spawnedBoxes.RemoveAt(0);
            }
        }

        float animWait = 0.5f;
        if (buttonAnimator != null)
        {
            AnimatorClipInfo[] clips = buttonAnimator.GetCurrentAnimatorClipInfo(0);
            if (clips.Length > 0)
                animWait = clips[0].clip.length;
        }

        yield return new WaitForSeconds(animWait);
        isAnimating = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Square"))
        {
            playerInside = true;

            if (buttonSprite != null)
                buttonSprite.color = glowColor;

            if (pressText != null)
                pressText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Square"))
        {
            playerInside = false;

            if (buttonSprite != null)
                buttonSprite.color = normalColor;

            if (pressText != null)
                pressText.SetActive(false);
        }
    }
}


