using UnityEngine;

public class MovePlatformUp : MonoBehaviour
{
    public Transform topPoint;
    public float speed = 2f;

    private bool moveUp = false;

    void Update()
    {
        if (!moveUp) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            topPoint.position,
            speed * Time.deltaTime
        );
    }

    public void StartMovingUp()
    {
        moveUp = true;
    }
}
