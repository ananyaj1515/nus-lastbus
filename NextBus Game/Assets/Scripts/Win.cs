using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject panel;   // UI panel to show

    void Start()
    {
        if (panel != null)
            panel.SetActive(false); // hide at start
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       panel.SetActive(true);
    }
    
}
