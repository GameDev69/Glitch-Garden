using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;
    private int _currentSceneIndex;

    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScene()); 
        }
    }
    private IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Scene");
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void LoadLoseScrene()
    {
        SceneManager.LoadScene("Lose Scene");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
