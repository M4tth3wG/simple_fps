using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;

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

        scoreText.text = GameController.instance.Artefacts.ToString();
    }
}
