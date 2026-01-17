using UnityEngine;

public class DinoMoveAlongRoad : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Vector3 moveDirection;

    void Start()
    {
        // Use the direction the road is facing
        moveDirection = transform.forward;
    }

   void Update()
{
    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
}
}

