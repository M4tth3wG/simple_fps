using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameConfiguration configuration;
    public int Health { get; private set; }
    public int Artefacts { get; private set; }
    public bool IsPaused { get; set; }

    private PlayerController player;
    private const string levelSceneName = "Level";
    private const string gameOverSceneName = "GameOver";
    private const float transitionDelay = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        player = FindObjectsOfType<PlayerController>()[0];
        Health = configuration.lives;
        player.transform.position = configuration.playerPosition;
        Artefacts = 0;
        IsPaused = false;
    }

    public void OnArtefactCollect()
    {
        Artefacts++;
    }

    public void OnPlayerDamaged()
    {
        if (Health > 0)
        {
            Health--;
        }

        if (Health == 0)
        {
            Debug.Log("Game over! You lose!");
            StartCoroutine(LoadSceneAfterDelay(gameOverSceneName, transitionDelay));
        }
    }

    public void OnEnemyKilled()
    {
        List<EnemyController> enemies = FindObjectsOfType<EnemyController>().ToList();

        if (!enemies.Any() || (enemies.All(e => !e.Alive)))
        {
            Debug.Log("Game over! You win!");
            StartCoroutine(LoadSceneAfterDelay(gameOverSceneName, transitionDelay));
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(levelSceneName);
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals(levelSceneName))
        {
            Init();
        }
    }

    public void OnMouseSpeedChanged(float speed)
    {
        player.rotationSpeed = speed;
        configuration.playerRotationSpeed = speed;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
