using UnityEngine;

public class BarricadeSwing : MonoBehaviour
{
    public float swingSpeed = 90f;   // degrees per second
    public float minAngle = 0f;      // horizontal
    public float maxAngle = 90f;     // vertical
    public float holdTime = 0.7f;    // time to pause at each end

    private bool goingUp = true;
    private float holdTimer = 0f;

    void Update()
    {
        float z = transform.eulerAngles.z;
        if (z > 180f) z -= 360f;

        if (holdTimer > 0f)
        {
            holdTimer -= Time.deltaTime;
            return;
        }

        float target = goingUp ? maxAngle : minAngle;
        float newZ = Mathf.MoveTowards(z, target, swingSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0f, 0f, newZ);

        if (Mathf.Abs(newZ - target) < 0.1f)
        {
            goingUp = !goingUp;
            holdTimer = holdTime; 
        }
    }
}
