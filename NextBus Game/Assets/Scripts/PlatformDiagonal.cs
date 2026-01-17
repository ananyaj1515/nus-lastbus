using UnityEngine;
using System.Collections;

public class PlatformDiagonal : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 3f;                   // movement speed
    [SerializeField] private Vector2 direction = new Vector2(5, -1); // right & down
    [SerializeField] private float startDelay = 0.5f;              // delay in seconds before moving

    private Vector2 _normalizedDir;
    private bool isMoving = false;       // controls whether platform moves
    private Coroutine startCoroutine;    // reference to running coroutine

    private void Awake()
    {
        _normalizedDir = direction.normalized;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(_normalizedDir * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BackWheel"))
        {
            // Start the delayed movement
            if (startCoroutine != null) StopCoroutine(startCoroutine);
            startCoroutine = StartCoroutine(StartMovingAfterDelay());
        }
        else if (collision.gameObject.CompareTag("Road"))
        {
            // Stop movement immediately
            if (startCoroutine != null) StopCoroutine(startCoroutine);
            isMoving = false;
        }
    }

    private IEnumerator StartMovingAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);
        isMoving = true;
    }

    // Optional: Trigger version
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackWheel"))
        {
            if (startCoroutine != null) StopCoroutine(startCoroutine);
            startCoroutine = StartCoroutine(StartMovingAfterDelay());
        }
        else if (collision.CompareTag("Road"))
        {
            if (startCoroutine != null) StopCoroutine(startCoroutine);
            isMoving = false;
        }
    }
}
