using UnityEngine;
using UnityEngine.Audio;

public class ChainSounds : MonoBehaviour
{
    public AudioSource chainSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle") && chainSound != null)
        {
             chainSound.Play();

           
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle") && chainSound != null)
        {
            chainSound.Stop();
        }
    }
}


