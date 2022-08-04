using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelControllers levelController;
    int _timeToWait = 3; // Для  стартовой заставки
    private int _currentSceneIndex;

    void Start()
    {
        NewVariableDeclaration();
        if (_currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScene()); 
        }
    }

    private void NewVariableDeclaration()
    {
        _timeToWait = levelController.TimeToWaitLoadScreen;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(_timeToWait);
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
