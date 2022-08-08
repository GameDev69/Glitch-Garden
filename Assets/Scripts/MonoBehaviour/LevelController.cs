using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelControllers levelController;

    private const string LoseLabelName = "Lose Canvas";
    private const string WinLabelName = "Level Complete Canvas";
    private const string OtherCanvasesName = "Other Canvases";
    private string _newInSceneTableName;
    
    private GameObject _otherCanvasesLabel;
    private GameObject _winLabel;
    private GameObject _loseLabel;
    private GameObject _newInSceneLabel;

    private float _waitToLoad = 2f; // Для переключений между уровнями
    private AudioSource _winSFX;
    private int _numberOfAttackers;
    private bool _levelTimeFinished;

    private void Start()
    {
        NewVariablesDeclaration();
        CheckingLabels();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_newInSceneLabel.activeSelf)
            {
                Time.timeScale = 1;
                _newInSceneLabel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                _newInSceneLabel.SetActive(true);
            }
        }
    }

    private void CheckingLabels()
    {
        if (_winLabel == null || _loseLabel == null) return;
        _winLabel.SetActive(false);
        _loseLabel.SetActive(false);
        _newInSceneLabel.SetActive(false);
    }

    private void NewVariablesDeclaration()
    {
        _newInSceneTableName = levelController.NewInSceneTableLabel;
        _loseLabel = GameObject.Find(LoseLabelName);
        _winLabel = GameObject.Find(WinLabelName);
        _otherCanvasesLabel = GameObject.Find(OtherCanvasesName);
        // Находит New In Scene Canvas в Level Related GameObjects
        _newInSceneLabel = _otherCanvasesLabel.
            transform.Find(_newInSceneTableName).gameObject;
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
