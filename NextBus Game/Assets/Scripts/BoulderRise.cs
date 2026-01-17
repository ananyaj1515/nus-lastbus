using UnityEngine;

public class BoulderRiseTrigger : MonoBehaviour
{
    public float riseHeight = 3f;
    public float riseSpeed = 3f;

    private Transform boulder;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool triggered = false;
    private bool rising = false;

    private Transform bus; // parent object of the FrontWheel

    void Start()
    {
        boulder = GameObject.FindGameObjectWithTag("Boulder").transform;

        startPos = boulder.position;
        targetPos = startPos + Vector3.up * riseHeight;
    }

    void Update()
    {
        if (rising)
        {
            boulder.position = Vector3.MoveTowards(
                boulder.position,
                targetPos,
                riseSpeed * Time.deltaTime
            );

            if (Vector3.Distance(boulder.position, targetPos) < 0.01f)
            {
                rising = false;
                // Optional: keep the bus parented if you want it stuck forever
                // bus.SetParent(null);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("FrontWheel"))
        {
            triggered = true;
            rising = true;

            // Parent the bus to the boulder
            bus = other.transform.root;
            bus.SetParent(boulder);
        }
    }
}
