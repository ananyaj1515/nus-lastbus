using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject panel;   // UI panel to show
    private AudioManger audioManager;

    void Start()
    {
        if (panel != null)
            panel.SetActive(false); // hide at start
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
       panel.SetActive(true);
       audioManager.StopMusic();
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.win);
        }
    }
    
}
