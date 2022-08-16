using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooserController : MonoBehaviour
{
    private const int LevelsCount = 4;
    private const int SectionsCount = 6;
    private int _pageNumber; // номер страницы для загрузки уровня при выборе
    private int _levelNumber; // вычисленный номер уровня для загрузки уровня при выборе
    private Button _previousPageButton;
    private Button _nextPageButton;
    private GameObject _scanningButton;
    private int _lastPassedLevel;

    private void Start()
    {
        // FindObjectOfType<SaveLoadData>().LoadData(); // Remove after testing
        _lastPassedLevel = FindObjectOfType<GameProgression>().LastPassedLevel;
        UpdateLevelLabels();
        _previousPageButton = GameObject.Find("Previous Page Button").GetComponent<Button>();
        _nextPageButton = GameObject.Find("Next Page Button").GetComponent<Button>();
    }

    private void Update()
    {
        PageChecking();
    }

    private void PageChecking()
    {
        _previousPageButton.interactable = true;
        if (_pageNumber <= 0)
        {
            _previousPageButton.interactable = false;
        }

        _nextPageButton.interactable = true;
        if (_pageNumber >= LevelsCount / SectionsCount)
        {
            _nextPageButton.interactable = false;
        }
    }

    public void NextPage()
    {
        _pageNumber++;
        UpdateLevelLabels();
    }

    public void PreviousPage()
    {
        _pageNumber--;
        UpdateLevelLabels();
    }

    private void UpdateLevelLabels()
    {
        for (int sectionNumber = 1; sectionNumber <= SectionsCount; sectionNumber++)
        {
            _levelNumber = 6 * (_pageNumber)  + sectionNumber;
            _scanningButton = GameObject.Find("Level Button " + sectionNumber);
            _scanningButton.transform.GetChild(0).GetComponent<Text>().text = "Level " + _levelNumber;
            Debug.Log($"{_lastPassedLevel} < {_levelNumber}");
            if (_lastPassedLevel < _levelNumber-1 || LevelsCount < _levelNumber)
            {
                _scanningButton.GetComponent<Button>().interactable = false;
            }
        }
        
    }

    public void LevelChoosen(int sectionNumber)
    {
        _levelNumber = 6 * (_pageNumber)  + sectionNumber;
        if (_levelNumber <= LevelsCount)
        {
            FindObjectOfType<LevelLoader>().LoadSelectedLevel(_levelNumber);
        }
        
    }
}
