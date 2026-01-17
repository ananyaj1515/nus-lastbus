using UnityEngine;

public class RestartTrigger : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    [SerializeField] private Rigidbody2D dino;

    private void OnTriggerEnter2D(Collider2D other)
    {
            BusFollower follower = dino.GetComponent<BusFollower>();
            if (follower != null)
            {
                Debug.Log("RestartTrigger activated. Restarting follower after delay.");
                follower.RestartFollowing(delay);
            }
        
    }
}
