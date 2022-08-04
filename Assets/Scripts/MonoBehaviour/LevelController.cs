using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelControllers levelController;

    private const string LoseLabelName = "Lose Canvas";
    private const string WinLabelName = "Level Complete Canvas";
    private const string InitialLabelName = "Initial Canvas";
    private GameObject _winLabel;
    private GameObject _loseLabel;
    private GameObject _initialLabel;
    private float _waitToLoad = 2f; // Для переключений между уровнями
    private AudioSource _winSFX;
    private int _numberOfAttackers;
    private bool _levelTimeFinished;

    private void Start()
    {
        NewVariablesDeclaration();
        CheckingLabels();
        HandleInstructions();
    }

    private void HandleInstructions()
    {
        Time.timeScale = 0;
        _initialLabel.SetActive(true);
    }

    private void CheckingLabels()
    {
        if (_winLabel == null || _loseLabel == null) return;
        _winLabel.SetActive(false);
        _loseLabel.SetActive(false);
    }

    private void NewVariablesDeclaration()
    {
        _loseLabel = GameObject.Find(LoseLabelName);
        _winLabel = GameObject.Find(WinLabelName);
        _initialLabel = GameObject.Find(InitialLabelName);
        _waitToLoad = levelController.WaitToLoadNextLevel;
        _winSFX = GetComponent<AudioSource>();
    }

    public void AttackerSpawned()
    {
        _numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        _numberOfAttackers--;
        if (_numberOfAttackers == 0 && _levelTimeFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        _winSFX.Play();
        _winLabel.SetActive(true);
        yield return new WaitForSeconds(_waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        _loseLabel.SetActive(true);
        _winLabel.SetActive(false);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        _levelTimeFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner attackerSpawner in spawnerArray)
        {
            attackerSpawner.StopSpawning();
        }
    }

    
}
