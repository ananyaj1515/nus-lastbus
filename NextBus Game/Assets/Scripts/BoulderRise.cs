using UnityEngine;
using System.Collections;

public class BoulderLift : MonoBehaviour
{
    [SerializeField] private Rigidbody2D boulder;
    [SerializeField] private float liftHeight = 3f;
    [SerializeField] private float liftDuration = 1f;

    private bool hasLifted = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!hasLifted && other.CompareTag("FrontWheel"))
        {
            StartCoroutine(LiftBoulder());
            hasLifted = true;
        }
    }

    private IEnumerator LiftBoulder()
    {
        Vector2 startPos = boulder.position;
        Vector2 targetPos = startPos + Vector2.up * liftHeight;
        float elapsed = 0f;

        boulder.bodyType = RigidbodyType2D.Dynamic;

        while (elapsed < liftDuration)
        {
            elapsed += Time.fixedDeltaTime;

            // Smooth upward motion using MovePosition
            Vector2 newPos = Vector2.Lerp(startPos, targetPos, elapsed / liftDuration);
            boulder.MovePosition(newPos);

            yield return new WaitForFixedUpdate();
        }

        boulder.MovePosition(targetPos);
        
    }
}
