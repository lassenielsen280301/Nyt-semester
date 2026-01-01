using UnityEngine;

public class PupilsFollowCircle : MonoBehaviour
{
    [Header("Pupils")]
    public Transform leftPupil;
    public Transform rightPupil;

    [Header("Movement")]
    public float maxOffset = 0.08f;
    public float followSpeed = 10f;

    private Transform circleTarget;
    private Vector3 leftStartPos;
    private Vector3 rightStartPos;

    private void Start()
    {
        GameObject circle = GameObject.FindGameObjectWithTag("Circle");
        if (circle != null)
            circleTarget = circle.transform;

        leftStartPos = leftPupil.localPosition;
        rightStartPos = rightPupil.localPosition;
    }

    private void Update()
    {
        if (circleTarget == null)
            return;

        MovePupil(leftPupil, leftStartPos);
        MovePupil(rightPupil, rightStartPos);
    }

    private void MovePupil(Transform pupil, Vector3 startPos)
    {
        if (pupil == null)
            return;

        Vector2 direction = (circleTarget.position - pupil.position).normalized;
        Vector3 targetOffset = (Vector3)direction * maxOffset;
        Vector3 targetPos = startPos + targetOffset;

        pupil.localPosition = Vector3.Lerp(
            pupil.localPosition,
            targetPos,
            followSpeed * Time.deltaTime
        );
    }
}
