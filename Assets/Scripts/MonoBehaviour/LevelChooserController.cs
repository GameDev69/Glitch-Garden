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

    private void Start()
    {
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
        if (_pageNumber <= 0)
        {
            _previousPageButton.interactable = false;
        }
        else
        {
            _previousPageButton.interactable = true;
        }

        if (_pageNumber >= LevelsCount / SectionsCount)
        {
            _nextPageButton.interactable = false;
        }
        else
        {
            _nextPageButton.interactable = true;
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
            GameObject.Find("Level Button " + sectionNumber).transform.GetChild(0).GetComponent<Text>().text = "Level " + _levelNumber;
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
