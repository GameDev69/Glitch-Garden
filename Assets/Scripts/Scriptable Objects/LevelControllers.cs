using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Controller")]
public class LevelControllers : ScriptableObject
{
    [SerializeField] private float levelDuration;
    [SerializeField] private float baseLives;
    [SerializeField] private int initialStars;
    [SerializeField] private int waitToLoadNextLevel;
    [SerializeField] private int timeToWaitLoadScreen;
    [SerializeField] private string newInSceneTableLabel;
    [SerializeField] private int levelNumber;

    public int LevelNumber => levelNumber;
    public int WaitToLoadNextLevel => waitToLoadNextLevel;
    public int TimeToWaitLoadScreen => timeToWaitLoadScreen;
    public float LevelDuration => levelDuration;
    public float BaseLives => baseLives;
    public int InitialStars => initialStars;
    public string NewInSceneTableLabel => newInSceneTableLabel;
}
