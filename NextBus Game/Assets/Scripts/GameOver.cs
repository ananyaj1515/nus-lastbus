using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    private bool isGameOver = false;
    public float stillTimeToLose = 3f;      // seconds
    public float stopSpeedThreshold = 0.1f; // how slow = "not moving"
    
    private AudioManger audioManager;
    private float stillTimer = 0f;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        // Try multiple ways to find AudioManager
        audioManager = FindFirstObjectByType<AudioManger>();
        if (audioManager == null)
        {
            audioManager = GameObject.Find("Audio")?.GetComponent<AudioManger>();
        }
        
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found!");
        }
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on " + gameObject.name);
        }
    }
    
    void Update()
    {
        if (isGameOver) return;
        
        // ----- Rotation check -----
        float z = transform.eulerAngles.z;
        if (z > 180) z -= 360;
        bool tippedOver = Mathf.Abs(z) > 90f;
        
        // ----- Movement check -----
        bool isNotMoving = rb.linearVelocity.magnitude < stopSpeedThreshold;
        
        if (isNotMoving)
        {
            stillTimer += Time.deltaTime;
        }
        else
        {
            stillTimer = 0f;
        }
        
        bool stoppedTooLong = stillTimer >= stillTimeToLose;
        
        // ----- Final condition -----
        if (tippedOver && stoppedTooLong)
        {
            Debug.Log("Game Over: Tipped over and stopped");
            TriggerGameOver();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over: Hit obstacle - " + collision.gameObject.name);
            TriggerGameOver();
        }
    }
    
    public void TriggerGameOver()
    {
        if (isGameOver) return; // Prevent multiple calls
        
        isGameOver = true;
        Debug.Log("TriggerGameOver called");
        
        // Play audio BEFORE freezing time
        audioManager.StopMusic();
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.death);
        }
        
        // Disable player input
        BusMovement busMovement = GetComponent<BusMovement>();
        if (busMovement != null)
        {
            busMovement.enabled = false;
        }
        
        // Show UI
        GameOverUI gameOverUI = FindFirstObjectByType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.Show();
        }
        else
        {
            Debug.LogError("GameOverUI not found!");
        }
        
        // Stop time LAST (so audio can play)
        Time.timeScale = 0f;
    }
}