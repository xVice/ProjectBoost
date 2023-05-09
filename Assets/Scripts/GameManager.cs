using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI fuelUI;
    public GameObject EscapeMenu;
    // Start is called before the first frame update
    void Start()
    {
        EscapeMenu = GameObject.Find("EscapeMenuCanvas");
        PauseResume();
        
    }
    public void PauseResume()
    {
        EscapeMenu.SetActive(!EscapeMenu.activeSelf);
        Time.timeScale = !EscapeMenu.activeSelf ? 1f : 0f;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotoFirstLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void GotoEndScene()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    // Update is called once per frame
    void Update()
    {
        if(EscapeMenu == null)
        {
            EscapeMenu = GameObject.Find("EscapeMenuCanvas");
            fuelUI = GameObject.Find("FuelUI").GetComponent<TextMeshProUGUI>();
            PauseResume();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResume();
        }
    }
}
