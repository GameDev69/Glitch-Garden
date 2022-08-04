using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{

    [SerializeField] private LevelControllers levelController;
    
    private int _stars = 100;
    private Text _starText;
    
    void Start()
    {
        NewVariablesDeclaration();
        UpdateDisplay();
    }

    private void NewVariablesDeclaration()
    {
        _stars = levelController.InitialStars;
        _starText = GetComponent<Text>();
    }

    private void UpdateDisplay()
    {
        _starText.text = _stars.ToString();
    }

    public bool HaveEnoughStars(int ammount)
    {
        return _stars >= ammount;
    }

    public void AddStars(int amount)
    {
        _stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (_stars >= amount)
        {
            _stars -= amount;
            UpdateDisplay();
        }
    }
}
