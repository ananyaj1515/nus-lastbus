using UnityEngine;

public class BusReappear_Lvl5 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // When the back wheel touches Road4
        if (collision.gameObject.CompareTag("Road4"))
        {
            ShowBus();
        }
    }

    void ShowBus()
    {
        string[] parts = { "BusBody", "FrontWheel", "BackWheel" };
        foreach (string tag in parts)
        {
            GameObject obj = GameObject.FindWithTag(tag);
            if (obj != null)
            {
                if (obj.TryGetComponent<SpriteRenderer>(out var sr))
                    sr.enabled = true;
            }
        }
    }
}