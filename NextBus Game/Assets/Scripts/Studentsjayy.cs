using UnityEngine;
using System.Collections;

public class StudentsDisappearTrigger : MonoBehaviour
{
    public GameObject studentsObject;
    public GameObject studentsObject2; // the students on the road
    public float disappearDelay = 2f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Bus"))
        {
            hasTriggered = true;
            // studentsObject.SetActive(true);
            // studentsObject2.SetActive(true); // show students
            StartCoroutine(HideStudentsAfterDelay());
        }
    }

    private IEnumerator HideStudentsAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay);
        studentsObject.SetActive(false);
        studentsObject2.SetActive(false); // hide students
    }
}
