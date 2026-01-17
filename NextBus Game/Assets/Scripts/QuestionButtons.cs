using UnityEngine;

public class QuestionButtons : MonoBehaviour
{
    public void ChooseCorrect()
    {
        // Find the bus
        GameObject busObj = GameObject.FindWithTag("Player");
        if (busObj != null)
        {
            Rigidbody2D busRb = busObj.GetComponent<Rigidbody2D>();
            if (busRb != null)
            {
                // Unfreeze the bus
                busRb.constraints = RigidbodyConstraints2D.None;
                busRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        // Destroy professor
        GameObject professor = GameObject.FindWithTag("Professor");
        Destroy(professor);
        GameObject question = GameObject.FindWithTag("Question");
        Destroy(question);

        

    }

    public void ChooseWrong()
    {
        FindObjectOfType<GameOver>().TriggerGameOver();

    }
}
