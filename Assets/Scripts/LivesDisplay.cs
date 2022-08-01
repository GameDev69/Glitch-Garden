using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private float baseHealth = 3;
    private Text _healthText;
    private float _health;
    private void Start()
    {
        _healthText = GetComponent<Text>();
        _health = baseHealth - PlayerPrefsController.GetDifficulty();
        UpdateDisplay();
    }
    
    public void DecreaseHealth(int point)
    {
        _health -= point;
        if (_health == 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _healthText.text = _health.ToString();
    }
}
