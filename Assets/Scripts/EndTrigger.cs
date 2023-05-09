using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public TextMeshProUGUI endTimeLabel;

    GameTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<GameTimer>();
        timer.FinishGame();
        endTimeLabel.text = $"Final Time: {timer.GetElapsedTime()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
