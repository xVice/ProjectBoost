using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjectsInTrigger : MonoBehaviour
{
    public GameObject rootOfFaders;

    public Transform[] objectsToFade;  // Array of game objects to fade out
    public float fadeTime = 1f;         // Time in seconds to fade out the objects
    public float minFadeDistance = 1f;  // Minimum distance to start fading out the objects
    public bool startFaded = false;     // Should the objects start already faded out?

    [SerializeField] List<Renderer> objectRenderers = new List<Renderer>();  // List of renderers of the objects to fade
    private bool playerInsideTrigger = false;                        // Is the player inside the trigger?
    private float fadeTimer = 0f;                                    // Timer for fading out the objects
    private float fadeAmount = 1f;                                   // Current alpha value for fading out the objects

    RocketMovement rocketController;

    // Start is called before the first frame update
    void Start()
    {
        rocketController = FindObjectOfType<RocketMovement>();
        objectsToFade = rootOfFaders.GetComponentsInChildren<Transform>();
        // Get the renderers of the objects to fade
        foreach (Transform obj in objectsToFade)
        {
            Renderer objRenderer = obj.gameObject.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                objectRenderers.Add(objRenderer);
            }
        }

        // Set the initial fade amount based on whether the objects should start already faded out
        UpdateObjectOpacity(startFaded ? 0 : 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is inside the trigger and within the minimum fade distance
        if (playerInsideTrigger)
        {
            // Start fading out the objects
            UpdateObjectOpacity(0);
        }
        else
        {
            // Fade the objects back in if the player is no longer inside the trigger or outside the minimum fade distance
            UpdateObjectOpacity(1);
        }
    }

    // Update the opacity of the objects to fade based on the current fade amount
    private void UpdateObjectOpacity(int opac)
    {
        Debug.Log("Fading");
        foreach (Transform objRenderer in objectsToFade)
        {
            if(opac == 1)
            {
                objRenderer.gameObject.SetActive(true);
            }
            else
            {
                objRenderer.gameObject.SetActive(false);
            }
        }
    }

    // Called when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Inside trigger");
            playerInsideTrigger = true;
        }
    }

    // Called when the player exits the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
        }
    }
}
