using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public bool isCounting = true;

    public TextMeshProUGUI timerText;
    public CanvasGroup failScreen;

    public float fadeSpeed = 1f;
    private bool hasFailed = false;

    private bool isPaused = false; // Pause flag

    public AudioSource gameOverSound;

    void Update()
    {
        // Toggle pause with Escape (only if game hasn't failed yet)
        if (!hasFailed && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Count down timer only if counting and not paused
        if (isCounting && !hasFailed && !isPaused)
        {
            timeRemaining -= Time.unscaledDeltaTime; // unscaled so pause works with UI
            if (timerText != null)
                timerText.text = Mathf.Ceil(timeRemaining).ToString();

            if (timeRemaining <= 0f)
            {
                TriggerFail();
            }
        }

        // Fade in fail screen (even while frozen)
        if (hasFailed && failScreen.alpha < 1f)
        {
            failScreen.alpha += Time.unscaledDeltaTime * fadeSpeed;
        }
    }

    void TriggerFail()
    {
        hasFailed = true;
        isCounting = false;

        PlayGameOverSound();
        failScreen.alpha = 0;
        failScreen.interactable = true;
        failScreen.blocksRaycasts = true;

        // Freeze the game
        Time.timeScale = 0f;
    }

    // Call this from your retry button
    public void RetryLevel()
    {
        Time.timeScale = 1f; // Unfreeze
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause game
        }
        else
        {
            Time.timeScale = 1f; // Resume game
        }
    }

    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
    }
}

