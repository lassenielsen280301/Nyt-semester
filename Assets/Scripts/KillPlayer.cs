using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // KillPlayers
    public GameObject Circle;
    public GameObject Square;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Circle") || collision.gameObject.CompareTag("Square"))
        {
            Dead();
        }
    }
    
    void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
