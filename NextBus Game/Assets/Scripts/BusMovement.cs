using UnityEngine;
using UnityEngine.InputSystem;

public class BusMovement : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private Rigidbody2D front;
    [SerializeField] private Rigidbody2D back;

    private float _moveInput;
    private float keyhelddown = 0f;

    private void Update()
    {
        if (Keyboard.current.downArrowKey.isPressed)
        {
            _moveInput = -1f;   
            if (keyhelddown < 5f)
                keyhelddown += Time.deltaTime;
        } else if (Keyboard.current.upArrowKey.isPressed)
        {
            _moveInput = 1f;
            if (keyhelddown < 5f)
            keyhelddown += Time.deltaTime;
        } else
        {
            _moveInput = 0f;
            keyhelddown = 0f;
        }   
    }

    private void FixedUpdate()
    {
        front.AddTorque(-_moveInput * speed * keyhelddown);
        back.AddTorque(-_moveInput * speed * keyhelddown);
    }
}