using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovePlatformUp platform;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Bus") || other.CompareTag("BackWheel"))
        {
            hasTriggered = true;
            platform.StartMovingUp();
        }
    }
}
