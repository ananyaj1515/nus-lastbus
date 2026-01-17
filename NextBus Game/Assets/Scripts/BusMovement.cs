using UnityEngine;
using UnityEngine.InputSystem;

public class BusMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D front;
    [SerializeField] private Rigidbody2D back;

private float _moveInput;
    private void FixedUpdate()
    {
        front.AddTorque(-_moveInput * speed * Time.fixedDeltaTime);
        back.AddTorque(-_moveInput * speed * Time.fixedDeltaTime);
    }

    private void Update() {
        _moveInput += Keyboard.current.leftArrowKey.isPressed ? -1f :
                     Keyboard.current.rightArrowKey.isPressed ? 1f : 0f;
    }
}
