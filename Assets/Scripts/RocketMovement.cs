using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using TMPro;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public TextMeshProUGUI fuelText;

    [SerializeField] float ThrustFactor = 100f;
    [SerializeField] float TurnFactor = 5f;
    [SerializeField] AudioClip EngineThrusters;
    [SerializeField] ParticleSystem[] ThrusterParticleSystems;
    [SerializeField] float fuel = 1500;
    [SerializeField] float fuelDeductAmmount = 25;

    GameManager gameManager;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        UpdateFuelDisplay();
    }

    void UpdateFuelDisplay()
    {
        gameManager.fuelUI.text = $"Fuel: {fuel.ToString("F0")}";
    }


    void ProcessThrust()
    {
        fuel = Mathf.Clamp(fuel, 0, 250);
        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddRelativeForce(Vector3.up * ThrustFactor * Time.deltaTime);
                if (Settings.UseFuel)
                {
                    fuel = fuel - fuelDeductAmmount * Time.deltaTime;
                }
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(EngineThrusters);
                }
                for (int i = 0; i < ThrusterParticleSystems.Count(); i++)
                {
                    ThrusterParticleSystems[i].Play();
                }
            }
            else
            {
                audioSource.Pause();
                for (int i = 0; i < ThrusterParticleSystems.Count(); i++)
                {
                    ThrusterParticleSystems[i].Stop();
                }
            }
        }
        else
        {
            audioSource.Pause();
            for (int i = 0; i < ThrusterParticleSystems.Count(); i++)
            {
                ThrusterParticleSystems[i].Stop();
            }
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(TurnFactor);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-TurnFactor);
        }
    }

    public void AddFuel(int ammount)
    {
        fuel += ammount;
    }

    void ApplyRotation(float turn)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * turn * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
