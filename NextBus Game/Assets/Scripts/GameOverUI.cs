using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void Show()
    {
        gameOverPanel.SetActive(true);
    }
    
    void Update()
{
    if (Time.timeScale == 0 && Keyboard.current.rKey.isPressed)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
}
