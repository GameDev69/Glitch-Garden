using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    [SerializeField] private float waitToLoad = 2f;
    private AudioSource _winSFX;
    private int _numberOfAttackers;
    private bool _levelTimeFinished;

    private void Start()
    {
        _winSFX = GetComponent<AudioSource>();
        if(winLabel == null || loseLabel == null) return;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
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
            Debug.Log("End Level Now");
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        _winSFX.Play();
        winLabel.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
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
