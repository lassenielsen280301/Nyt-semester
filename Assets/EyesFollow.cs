using UnityEngine;

public class PupilsFollowSquare : MonoBehaviour
{
    [Header("Pupils")]
    public Transform leftPupil;
    public Transform rightPupil;

    [Header("Movement")]
    public float maxOffset = 0.08f;   // how far pupils can move
    public float followSpeed = 10f;

    private Transform squareTarget;
    private Vector3 leftStartPos;
    private Vector3 rightStartPos;

    private void Start()
    {
        GameObject square = GameObject.FindGameObjectWithTag("Square");
        if (square != null)
            squareTarget = square.transform;

        leftStartPos = leftPupil.localPosition;
        rightStartPos = rightPupil.localPosition;
    }

    private void Update()
    {
        if (squareTarget == null)
            return;

        MovePupil(leftPupil, leftStartPos);
        MovePupil(rightPupil, rightStartPos);
    }

    private void MovePupil(Transform pupil, Vector3 startPos)
    {
        if (pupil == null)
            return;

        Vector2 direction = (squareTarget.position - pupil.position).normalized;
        Vector3 targetOffset = (Vector3)direction * maxOffset;
        Vector3 targetPos = startPos + targetOffset;

        pupil.localPosition = Vector3.Lerp(
            pupil.localPosition,
            targetPos,
            followSpeed * Time.deltaTime
        );
    }
}
