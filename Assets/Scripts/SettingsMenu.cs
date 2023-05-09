using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI slider used to adjust volume
    public Toggle useFuelToggle;

    void Start()
    {
        useFuelToggle.isOn = Settings.UseFuel;
        volumeSlider.value = AudioListener.volume;

        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        useFuelToggle.onValueChanged.AddListener(OnFuelToggle);
    }

    public void OnFuelToggle(bool state)
    {
        Settings.UseFuel = state;
    }

    public void ChangeVol(float newValue)
    {
        float newVol = AudioListener.volume;
        newVol = newValue;
        AudioListener.volume = newVol;
    }
    // Called when the volume slider is moved
    public void OnVolumeSliderChanged(float ammount)
    {
        // Set the volume level to the slider's value
        ChangeVol(ammount);
    }
}
