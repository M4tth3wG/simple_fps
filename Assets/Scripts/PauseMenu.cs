using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuOverlay;
    public Slider mouseSlider;
    public Slider volumeSlider;
    public AudioMixer audioMixer;

    void Start()
    {
        menuOverlay.SetActive(false);

        mouseSlider.minValue = GameController.instance.configuration.minPlayerRotationSpeed;
        mouseSlider.maxValue = GameController.instance.configuration.maxPlayerRotationSpeed;
        mouseSlider.value = GameController.instance.configuration.playerRotationSpeed;
        mouseSlider.onValueChanged.AddListener(OnMouseSpeedChanged);

        volumeSlider.minValue = 0.0001f;
        volumeSlider.maxValue = 1;
        volumeSlider.value = GameController.instance.configuration.volume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameController.instance.IsPaused)
            {
                ResumeGame();
            }
            else { 
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        GameController.instance.IsPaused = true;
        menuOverlay.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        GameController.instance.IsPaused = false;
        menuOverlay.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame()
    {
        ResumeGame();
        GameController.instance.RestartGame();
    }

    void OnMouseSpeedChanged(float speed)
    {
        GameController.instance.OnMouseSpeedChanged(speed);
    }

    void OnVolumeChanged(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        GameController.instance.configuration.volume = volume;
    }
}
