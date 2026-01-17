using UnityEngine;

public class SpinInPlace : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 180f, 0f); // degrees per second

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
