using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    public GameObject roadToDisappear;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Bus")) 
        {
            hasTriggered = true;
            roadToDisappear.SetActive(false);
        }
    }
}
