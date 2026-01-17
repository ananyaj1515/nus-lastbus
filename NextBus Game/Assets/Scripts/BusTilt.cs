using UnityEngine;
using UnityEngine.InputSystem;

public class BusTilt : MonoBehaviour
{
    [SerializeField] float tiltTorque = 50f;
    [SerializeField] Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float tilt = 0f;
        var kb = Keyboard.current;

        if (kb.upArrowKey.isPressed) tilt = 1f;
        else if (kb.downArrowKey.isPressed) tilt = -1f;

        rb.AddTorque(-tilt * tiltTorque);
    }
}
