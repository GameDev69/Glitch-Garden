using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MasterVolumeKey = "master volume";
    private const string DifficultyKey = "difficulty";
    
    
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MinVolume && volume <= MaxVolume)
        {
            Debug.Log("Громкость звука установлена в " + volume);
            PlayerPrefs.SetFloat(MasterVolumeKey, volume);
        }
        else
        {
            Debug.Log("Master volume is out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MasterVolumeKey);
    }
}
