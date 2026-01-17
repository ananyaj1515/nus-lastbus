using UnityEngine;

public class QuestionTrigger_Lvl3 : MonoBehaviour
{
    public GameObject questionCanvas;   // Canvas GameObject
    private bool triggered = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            triggered = true;

            Rigidbody2D busRb = collision.gameObject
                .GetComponentInParent<Rigidbody2D>();

            if (busRb != null)
            {
                busRb.linearVelocity = Vector2.zero;
                busRb.constraints = RigidbodyConstraints2D.FreezeAll;

            }

            questionCanvas.SetActive(true);
        }
    }
}
