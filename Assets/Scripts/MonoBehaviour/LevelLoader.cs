using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelControllers levelController;
    
    int _timeToWait = 3; // Для  стартовой заставки
    private int _currentSceneIndex;
    private GameProgression _gameProgression;
    

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
        _gameProgression = FindObjectOfType<GameProgression>();
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
        _gameProgression.ResetGame();
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

    public void LoadLevelsScene()
    {
        SceneManager.LoadScene("Load Level Scene");
    }

    public void LoadSelectedLevel(int levelNumber)
    {
        SceneManager.LoadScene("Level " + levelNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
