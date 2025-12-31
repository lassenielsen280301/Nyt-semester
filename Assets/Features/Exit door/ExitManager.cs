using UnityEngine;
using static ExitManager;

public class ExitTrigger : MonoBehaviour
{

    [SerializeField] private ExitManager exitManager;

    public enum ExitType
    {
        Circle,
        Square
    }

    [SerializeField] private ExitType exitType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitManager = FindAnyObjectByType<ExitManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (exitType == ExitType.Circle && collision.CompareTag("Circle"))
        {
            exitManager.circleInside = true;
            Debug.Log("Circle i Circle-dør");
        }

        if (exitType == ExitType.Square && collision.CompareTag("Square"))
        {
            exitManager.squareInside = true;
            Debug.Log("Square i Square-dør");
        }

        exitManager.CheckBothPlayers();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (exitType == ExitType.Circle && collision.CompareTag("Circle"))
        {
            exitManager.circleInside = false;
        }

        if (exitType == ExitType.Square && collision.CompareTag("Square"))
        {
            exitManager.squareInside = false;
        }
    }
}
