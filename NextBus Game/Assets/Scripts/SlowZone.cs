using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [SerializeField] private float slowAngularDrag = 8f;
    [SerializeField] private float slowLinearDrag = 4f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FrontWheel"))
        {
            Rigidbody2D rb = other.attachedRigidbody;
            if (rb != null)
            {
                rb.angularDamping += slowAngularDrag;
                rb.linearDamping += slowLinearDrag;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("FrontWheel"))
        {
            Rigidbody2D rb = other.attachedRigidbody;
            if (rb != null)
            {
                rb.angularDamping -= slowAngularDrag;
                rb.linearDamping -= slowLinearDrag;
            }
        }
    }
}
