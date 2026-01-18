using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Map");
    }
}
