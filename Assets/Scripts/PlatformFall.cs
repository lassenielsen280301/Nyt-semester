using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float requiredWeight = 20f;

    public HingeJoint2D leftChainJoint;
    public HingeJoint2D rightChainJoint;

    private float currentWeight = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        BoxWeight w = other.GetComponent<BoxWeight>();
        if (w != null)
        {
            currentWeight += w.weight;
            CheckWeight();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        BoxWeight w = other.GetComponent<BoxWeight>();
        if (w != null)
        {
            currentWeight -= w.weight;
        }
    }

    void CheckWeight()
    {
        if (currentWeight >= requiredWeight)
        {
            BreakChains();
        }
    }

    void BreakChains()
    {
        if (leftChainJoint != null)
            Destroy(leftChainJoint);

        if (rightChainJoint != null)
            Destroy(rightChainJoint);

        // Makes Platform fall, by changing from kinematic to dynamic after weight has reached
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}

