using UnityEngine;
using System.Collections;

public class ChickenSpawnTrigger : MonoBehaviour
{
    public GameObject chickenPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;   // empty object in the sky
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Bus"))
        {
            hasTriggered = true;
            StartCoroutine(SpawnChickensWithDelay());
        }
    }

    private IEnumerator SpawnChickensWithDelay()
    {
        Instantiate(chickenPrefab, spawnPoint1.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        Instantiate(chickenPrefab, spawnPoint2.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        Instantiate(chickenPrefab, spawnPoint3.position, Quaternion.identity);
    }


    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (hasTriggered) return;

    //     if (other.CompareTag("Bus"))
    //     {
    //         hasTriggered = true;
    //         Instantiate(chickenPrefab, spawnPoint1.position, Quaternion.identity);
    //         Instantiate(chickenPrefab, spawnPoint2.position, Quaternion.identity);
    //         Instantiate(chickenPrefab, spawnPoint3.position, Quaternion.identity);
    //     }
    // }
}
