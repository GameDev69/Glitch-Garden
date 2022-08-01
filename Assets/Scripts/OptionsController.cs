using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 0.5f;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private int defaultDifficulty;
    
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.Log("No music player found... did you start from splash screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
