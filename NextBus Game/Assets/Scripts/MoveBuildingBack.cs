using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D buildingRb;
    [SerializeField] private float moveDistance = 4.22f;
    [SerializeField] private float moveSpeed = 5f;
    
    private bool isMoving = false;
    private Vector2 startPos;
    private Vector2 targetPos;
    private float moveProgress = 0f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger ENTER by: {other.gameObject.name}");
        
        if(other.gameObject.CompareTag("FrontWheel") && !isMoving)
        {
            startPos = buildingRb.position;
            targetPos = buildingRb.position + Vector2.right * moveDistance;
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
            buildingRb.MovePosition(newPos);
            
            // Stop when reached target
            if(moveProgress >= 1f)
            {
                isMoving = false;
                buildingRb.MovePosition(targetPos); // Snap to exact position
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Trigger EXIT by: {other.gameObject.name}");
    }
}