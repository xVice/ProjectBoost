using UnityEngine;
using TMPro;

public class SpeedRunTimer : MonoBehaviour
{
    private float startTime;
    private bool timerRunning;
    public TextMeshProUGUI timerText;

    // Static instance to ensure only one timer exists
    private static SpeedRunTimer instance;

    private void Awake()
    {
        // Check if an instance already exists and destroy this one if so
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton instance
        instance = this;

        // Make the timer object persistent across scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Initialize the timer to be not running
        timerRunning = false;
    }

    private void Update()
    {
        if (timerRunning)
        {
            float timeElapsed = Time.time - startTime;
            DisplayTime(timeElapsed);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    private void DisplayTime(float timeToDisplay)
    {
        // Convert the timeToDisplay to minutes and seconds
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Update the timer text object
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to show or hide the timer based on a boolean
    public void ShowTimer(bool show)
    {
        timerText.gameObject.SetActive(show);
    }
}
