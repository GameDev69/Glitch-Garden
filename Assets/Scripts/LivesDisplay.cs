using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    
    [SerializeField] private int health = 99;
    private Text _healthText;
    private void Start()
    {
        _healthText = GetComponent<Text>();
        UpdateDisplay();
    }
    
    public void DecreaseHealth(int point)
    {
        health -= point;
        if (health == 0)
        {
            FindObjectOfType<LevelLoader>().LoadLoseScrene();
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _healthText.text = health.ToString();
    }
}
