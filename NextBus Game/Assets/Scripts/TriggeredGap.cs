using UnityEngine;

public class TriggeredGap : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveDistance = 4.22f;
    [SerializeField] private float moveSpeed = 5f;
    
    private bool isMoving = false;
    private Vector2 startPos;
    private Vector2 targetPos;
    private float moveProgress = 0f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger ENTER by: {other.gameObject.name}");
        
        if(other.gameObject.CompareTag("BackWheel") && !isMoving)
        {
            startPos = rb.position;
            targetPos = rb.position + Vector2.right * moveDistance;
            isMoving = true;
            moveProgress = 0f;
        }
    }
    
    private void FixedUpdate()
    {
        if(isMoving)
        {
            moveProgress += Time.fixedDeltaTime * moveSpeed;
            
            // Smooth interpolation
            float t = Mathf.SmoothStep(0f, 1f, moveProgress);
            Vector2 newPos = Vector2.Lerp(startPos, targetPos, t);
            rb.MovePosition(newPos);
            
            // Stop when reached target
            if(moveProgress >= 1f)
            {
                isMoving = false;
                rb.MovePosition(targetPos); // Snap to exact position
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Trigger EXIT by: {other.gameObject.name}");
    }
}