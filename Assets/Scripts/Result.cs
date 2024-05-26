using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI artefactsText;
    public TextMeshProUGUI timerText;

    private const string loseMessage = "YOU LOSE";
    private const string winMessage = "YOU WIN";

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (GameController.instance.Health == 0)
        {
            resultText.text = loseMessage;
            resultText.color = Color.red;
        }
        else {
            resultText.text = winMessage;
            resultText.color = Color.green;
        }

        artefactsText.text = GameController.instance.Artefacts.ToString();
        timerText.text = GetFormatedTime();
    }

    string GetFormatedTime()
    {
        float time = GameController.instance.ElapsedTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{00:00}:{01:00}", minutes, seconds);
    }
}
