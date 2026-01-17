using UnityEngine;

public class BarricadeState : MonoBehaviour
{
    [Header("Angles")]
    public float verticalThreshold = 70f;   // degrees
    public float horizontalThreshold = 20f; // degrees

    private Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        float z = Mathf.Abs(transform.eulerAngles.z);
        if (z > 180f) z -= 360f; 

        z = Mathf.Abs(z);

        bool isVertical = z > verticalThreshold;
        bool isHorizontal = z < horizontalThreshold;

        if (isVertical)
        {
            col.enabled = false; 
        }
        else if (isHorizontal)
        {
            col.enabled = true;  
        }
    }
}
