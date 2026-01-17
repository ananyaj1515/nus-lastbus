using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    private bool isGameOver = false;

    public float stillTimeToLose = 3f;      // seconds
    public float stopSpeedThreshold = 0.1f; // how slow = "not moving"

    private float stillTimer = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGameOver) return;

        // ----- Rotation check -----
        float z = transform.eulerAngles.z;
        if (z > 180) z -= 360;

        bool tippedOver = Mathf.Abs(z) > 90f;

        // ----- Movement check -----
        bool isNotMoving = rb.linearVelocity.magnitude < stopSpeedThreshold;

        if (isNotMoving)
        {
            stillTimer += Time.deltaTime;
        }
        else
        {
            stillTimer = 0f;
        }

        bool stoppedTooLong = stillTimer >= stillTimeToLose;

        // ----- Final condition -----
        if (tippedOver && stoppedTooLong)
        {
            TriggerGameOver();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true;

        FindFirstObjectByType<GameOverUI>()?.Show();

        // Stop time
        Time.timeScale = 0f;

        // Optional: disable player input
        GetComponent<BusMovement>().enabled = false;
    }
}