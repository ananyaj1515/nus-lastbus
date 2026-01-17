using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [Header("Light References")]
    [SerializeField] private GameObject redLight;
    [SerializeField] private GameObject greenLight;
    
    [Header("Timing Settings")]
    [SerializeField] private float redDuration = 4f;
    [SerializeField] private float greenDuration = 2f;
    
    [Header("Barrier Settings")]
    [SerializeField] private GameObject barrierObject;
    
    private float timer;
    private bool isRed = true;
    
    void Start()
    {
        UpdateLight();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        float currentDuration = isRed ? redDuration : greenDuration;
        
        if (timer >= currentDuration)
        {
            isRed = !isRed;
            timer = 0f;
            UpdateLight();
        }
    }
    
    void UpdateLight()
    {
        redLight.SetActive(isRed);
        greenLight.SetActive(!isRed);
        barrierObject.SetActive(isRed); // Activate barrier when red
    }
}