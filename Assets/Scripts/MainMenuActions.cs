using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotoFirstLevel()
    {
        SceneManager.LoadScene(3);
    }

}
