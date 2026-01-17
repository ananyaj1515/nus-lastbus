using UnityEngine;

public class StudentFly : MonoBehaviour
{
    public float flyForceX = 8f;
    public float flyForceY = 12f;
    public float spinTorque = 5f;

    private Rigidbody2D rb;
    private bool hasFlown = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasFlown) return;

        if (other.CompareTag("death"))
        {
            hasFlown = true;

            rb.linearVelocity = Vector2.zero; // reset motion
            rb.AddForce(new Vector2(flyForceX, flyForceY), ForceMode2D.Impulse);
            rb.AddTorque(spinTorque, ForceMode2D.Impulse);
        }
    }
}
