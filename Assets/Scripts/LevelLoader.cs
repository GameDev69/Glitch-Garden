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

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }
}
