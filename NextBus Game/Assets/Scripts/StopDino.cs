using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
            BusFollower follower = other.GetComponent<BusFollower>();
            if (follower != null)
            {
                Debug.Log("StopTrigger activated. Stopping follower.");
                follower.StopFollowing();
            }
   }
}