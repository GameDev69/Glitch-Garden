using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] private float levelTime = 10;
    private bool _triggeredLevelFinished = false;

    void Update()
    {
        if(_triggeredLevelFinished) return;
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime * 100;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            _triggeredLevelFinished = true;
        }
    }
}
