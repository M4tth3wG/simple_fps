using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public TextMeshProUGUI livesDisplay;
    public TextMeshProUGUI artefactsDisplay;
    public TextMeshProUGUI enemiesDisplay;
    public TextMeshProUGUI timerDisplay;

    void Start()
    {
        OnLivesUpdate();
        OnArtefactsUpdate();
        OnEnemiesUpdate();
        UpdateTime();
    }

    private void Update()
    {
        OnLivesUpdate();
        OnArtefactsUpdate();
        OnEnemiesUpdate();
        UpdateTime();
    }

    private void UpdateTime()
    {
        float time = GameController.instance.ElapsedTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerDisplay.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    void OnLivesUpdate()
    {
        livesDisplay.text = GameController.instance.Health.ToString();
    }

    void OnArtefactsUpdate()
    {
        artefactsDisplay.text = GameController.instance.Artefacts.ToString();
    }

    void OnEnemiesUpdate()
    {
        enemiesDisplay.text = GameController.instance.Enemies.ToString();
    }
}
