using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CongratsUI : MonoBehaviour
{
    public Button RestartButton;
    public Button MainMenuButton;

    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        RestartButton.onClick.AddListener(RestartGameButton);
        MainMenuButton.onClick.AddListener(MainMenuButtonLogic);
    }

    void RestartGameButton()
    {
        gameManager.GotoFirstLevel();
    }

    void MainMenuButtonLogic()
    {
        gameManager.OpenMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
