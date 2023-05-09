using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    private bool gameFinished;

    private static GameTimer instance;

    private void Awake()
    {
        // Implementing DontDestroyOnLoad to keep the timer running across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("Resetting time");
        startTime = Time.time;
    }

    private void Update()
    {
        if (!gameFinished)
        {
            elapsedTime = Time.time - startTime;
        }
        else
        {
            // Game is finished, do something with the elapsed time here
            Debug.Log("Elapsed Time: " + elapsedTime);
        }
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    // This method is called by the other class to signal that the game is finished
    public void FinishGame()
    {
        gameFinished = true;
    }
}