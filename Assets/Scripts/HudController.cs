using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public TextMeshProUGUI livesDisplay;
    public TextMeshProUGUI artifactsDisplay;

    void Start()
    {
        OnLivesUpdate();
        OnArtifactsUpdate();
    }

    private void Update()
    {
        OnLivesUpdate();
        OnArtifactsUpdate();
    }

    void OnLivesUpdate()
    {
        livesDisplay.text = GameController.instance.Health.ToString();
    }

    void OnArtifactsUpdate()
    {
        artifactsDisplay.text = GameController.instance.Artefacts.ToString();
    }
}
