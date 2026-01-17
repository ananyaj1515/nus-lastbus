using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float delay = 0f;
    
    private Vector3 startPos;
    private float timer;
    
    void Start()
    {
        startPos = transform.position;
        timer = -delay; // Start with negative time for delay
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 0)
        {
            float offset = Mathf.Sin(timer * moveSpeed) * moveDistance;
            transform.position = startPos + new Vector3(0, offset, 0);
        }
    }
}