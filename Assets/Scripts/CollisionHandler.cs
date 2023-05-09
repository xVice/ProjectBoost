using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float EndDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip sucsess;
    [SerializeField] AudioClip sucsess2;
    [SerializeField] ParticleSystem SucsessParticles;
    [SerializeField] ParticleSystem ExplosionParticles;

    AudioSource audioSource;
    RocketMovement rocketMovement;

    bool isTransitioning = false;
    bool isSpeedrun = false;
    bool isGodMode = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rocketMovement = FindObjectOfType<RocketMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCrash();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isGodMode = !isGodMode;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isTransitioning)
        {
            switch (collision.transform.tag)
            {
                case "Friendly":
                    Debug.Log("Friend");
                    break;
                case "Hostile":
                    if (isGodMode) break;
                    StartCrash();
                    break;
                case "Finish":
                    GotoNextLevel();
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTransitioning)
        {
            switch (other.transform.tag)
            {
                case "Speedrun":
                    StartSpeedRunTimer();
                    break;
                case "Fuel":
                    RefuelRocket(other.gameObject, 10);
                    break;
                case "Fuel1":
                    RefuelRocket(other.gameObject, 20);
                    break;
                case "Fuel2":
                    RefuelRocket(other.gameObject, 30);
                    break;
            }
        }
    }

    void RefuelRocket(GameObject other, int ammount)
    {
        isTransitioning = true;
        rocketMovement.AddFuel(ammount);
        audioSource.PlayOneShot(sucsess2);
        Destroy(other);
        isTransitioning = false;
    }

    void StartSpeedRunTimer()
    {
        if(isSpeedrun == false)
        {
            isSpeedrun = true;
        }
    }

    void StartCrash()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(crash);
        ExplosionParticles.Play();
        DisableMovement();
        Invoke("ReloadLevel", EndDelay);
    }

    void GotoNextLevel()
    {
        isTransitioning = true;
        DisableMovement();
        audioSource.PlayOneShot(sucsess);
        SucsessParticles.Play();
        Invoke("LoadNextLevel", EndDelay);
    }

    void DisableMovement()
    {
        rocketMovement.enabled = false;
    }

    void ReloadLevel()
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex, LoadSceneMode.Single);
    }

    void LoadNextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
