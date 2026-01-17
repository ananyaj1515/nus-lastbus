using UnityEngine;

public class BusJump : MonoBehaviour
{
    public float jumpVelocity = 18f;
    public float forwardVelocity = 12f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("JumpPlatform")) return;

        rb.linearVelocity = new Vector2(
            Mathf.Max(rb.linearVelocity.x, forwardVelocity),
            jumpVelocity
        );
    }
}
