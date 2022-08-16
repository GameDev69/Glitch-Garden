using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameProgression : MonoBehaviour
{
    private int _lastPassedLevel;

    public int LastPassedLevel
    {
        get => _lastPassedLevel;
        set => _lastPassedLevel = value;
    }

    private void Awake()
    {
        int levelProgression = FindObjectsOfType<GameProgression>().Length;
        if(levelProgression > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
