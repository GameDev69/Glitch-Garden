using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private LevelControllers levelController;
    private float _baseLives = 3;
    private Text _healthText;
    private float _health;
    private void Start()
    {
        NewVariablesDeclaration();
        UpdateDisplay();
    }

    private void NewVariablesDeclaration()
    {
        _baseLives = levelController.BaseLives;
        _healthText = GetComponent<Text>();
        _health = _baseLives - PlayerPrefsController.GetDifficulty();
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
