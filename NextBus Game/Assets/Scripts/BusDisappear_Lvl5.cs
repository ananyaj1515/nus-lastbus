using UnityEngine;

public class BusDisappear_Lvl5 : MonoBehaviour
{
    public float delay = 2.0f; // Changed to 2 seconds as requested
    private bool hasDisappeared = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // When this wheel (FrontWheel) touches Road3
        if (!hasDisappeared && collision.gameObject.CompareTag("Road3"))
        {
            hasDisappeared = true;
            Invoke("HideBus", delay);
        }
    }

    void HideBus()
    {
        SetBusVisibility(false);
    }

    public void SetBusVisibility(bool visible)
    {
        string[] parts = { "BusBody", "FrontWheel", "BackWheel" };
        foreach (string tag in parts)
        {
            GameObject obj = GameObject.FindWithTag(tag);
            if (obj != null)
            {
                if (obj.TryGetComponent<SpriteRenderer>(out var sr))
                    sr.enabled = visible;
            }
        }
    }
}