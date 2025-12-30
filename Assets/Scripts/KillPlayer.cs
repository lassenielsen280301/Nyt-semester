using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    [Header("Global death sound")]
    public CharacterDeathSound globalDeathSound;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return;

        if (collision.CompareTag("Square") || collision.CompareTag("Circle"))
        {
            hasTriggered = true;
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {

        if (globalDeathSound != null)
        {
            globalDeathSound.PlayDeathSound();
        }

        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
