using UnityEngine;

public class BoulderMove : MonoBehaviour
{
    public float topY = 5f;
    public float bottomY = 0f;
    public float speed = 2f;

    private bool goingUp = true;

    void Update()
    {
        float targetY = goingUp ? topY : bottomY;
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(transform.position.x, targetY, transform.position.z),
            speed * Time.deltaTime
        );

        if (Mathf.Abs(transform.position.y - targetY) < 0.01f)
        {
            goingUp = !goingUp;
        }
    }
}
