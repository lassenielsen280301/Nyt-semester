using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private Vector3 currentTarget;

    void Start()
    {
        startPosition = transform.position;
        currentTarget = startPosition;

        if (targetPosition == null)
            Debug.LogError("PressurePlateController: No targetPosition assigned!");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
    }

    public void Activate()
    {
        currentTarget = targetPosition.position;
    }

    public void Release()
    {
        currentTarget = startPosition;
    }
}

