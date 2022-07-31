using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(0.9f);
        Debug.Log(PlayerPrefsController.GetMasterVolume());
    }

    void Update()
    {
        
    }
}
