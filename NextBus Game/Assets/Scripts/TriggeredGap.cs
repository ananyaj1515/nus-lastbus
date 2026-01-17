using UnityEngine;

public class TriggeredGap : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveDistance = 4.22f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger ENTER by: {other.gameObject.name}");
        // Move right by moveDistance
        if(other.gameObject.CompareTag("Back Wheel"))
        {
            rb.MovePosition(rb.position + Vector2.right * moveDistance);
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Trigger EXIT by: {other.gameObject.name}");
    }
}
