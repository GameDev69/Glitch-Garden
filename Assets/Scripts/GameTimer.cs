using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] private float levelTime = 10;

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime * 100;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            Debug.Log("Level timer expired");
        }
    }
}
