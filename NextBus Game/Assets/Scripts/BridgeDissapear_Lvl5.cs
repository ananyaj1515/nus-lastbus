using UnityEngine;
using UnityEngine.U2D;

public class BridgeDisappear_Lvl5 : MonoBehaviour
{
    public float delay = 0.5f;

    private SpriteShapeRenderer ssr;
    private Collider2D col;
    private bool triggered = false;

    void Start()
    {
        ssr = GetComponent<SpriteShapeRenderer>();
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;

        if (collision.gameObject.CompareTag("FrontWheel"))
        {
            triggered = true;
            Invoke("Disappear", delay);
        }
    }

    void Disappear()
    {
        ssr.enabled = false;
        col.enabled = false;
    }
}
