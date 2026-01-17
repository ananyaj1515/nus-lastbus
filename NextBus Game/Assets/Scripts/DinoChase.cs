using UnityEngine;
using System.Collections;

public class BusFollower : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bus;         
    [SerializeField] private float horizontalOffset = 5f; 
    [SerializeField] private float followSpeed = 10f;     
    [SerializeField] private float startDelay = 1f;       

    private bool canFollow = false;

    private void Start()
    {
        StartCoroutine(StartFollowingAfterDelay(startDelay));
    }

    private IEnumerator StartFollowingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canFollow = true;
    }

    private void LateUpdate()
    {
        if (!canFollow || bus == null) return;

        Vector3 targetPos = new Vector3(
            bus.position.x - horizontalOffset,
            bus.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    // Call this to stop following immediately
    public void StopFollowing()
    {
        canFollow = false;
    }

    // Call this to restart following after a delay
    public void RestartFollowing(float delay)
    {
        StartCoroutine(StartFollowingAfterDelay(delay));
    }
}
