using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class TrafficTriggeredCollider : MonoBehaviour
{
    [SerializeField] private float activeTime = 5f;

    private Collider2D col;
    private Coroutine routine;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        col.enabled = true; // start ON for testing
        Debug.Log($"[{name}] Collider initial state: {col.enabled}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"[{name}] Collision with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Traffic"))
        {
            Debug.Log("Traffic hit → enabling collider for 5 seconds");
            StartTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"[{name}] Trigger with: {collision.gameObject.name}");

        if (collision.CompareTag("Traffic"))
        {
            Debug.Log("Traffic trigger → enabling collider for 5 seconds");
            StartTimer();
        }
    }

    private void StartTimer()
    {
        if (routine != null)
            StopCoroutine(routine);

        routine = StartCoroutine(ColliderTimer());
    }

    private IEnumerator ColliderTimer()
    {
        col.enabled = true;
        Debug.Log("Collider ENABLED");

        yield return new WaitForSeconds(activeTime);

        col.enabled = false;
        Debug.Log("Collider DISABLED");
    }
}
