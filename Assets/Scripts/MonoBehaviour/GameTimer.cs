using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private LevelControllers levelControllers;
    
    private float _levelTime = 10;
    private bool _triggeredLevelFinished = false;

    private void Start()
    {
        _levelTime = levelControllers.LevelDuration;
    }

    void Update()
    {
        UpdateSliderProgress();
    }

    private void UpdateSliderProgress()
    {
        if (_triggeredLevelFinished) return;
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / _levelTime * 100;

        bool timerFinished = (Time.timeSinceLevelLoad >= _levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            _triggeredLevelFinished = true;
        }
    }
    
    // Получение отношения пройденного времени и времени уровня в целом в виде процентов
    public float GetRatioOfTime() 
    {
        return GetComponent<Slider>().value;
    }
}
