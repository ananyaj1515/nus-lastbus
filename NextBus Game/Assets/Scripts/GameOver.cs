using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    private bool isGameOver = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;

        FindFirstObjectByType<GameOverUI>()?.Show();

        // Stop time
        Time.timeScale = 0f;

        // Optional: disable player input
        GetComponent<BusMovement>().enabled = false;
    }
}
