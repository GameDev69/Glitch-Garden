using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DefenderSpawner : MonoBehaviour
{

    private Defender _defender;
    
    private void OnMouseDown() // При нажатии на ЛКМ
    {
        if (_defender == null) return;
        // Создание Defener в полученный квадрат
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect) // Установка префаба для Defener
    {
        _defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = _defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost)) // if ve have enough stars
        {
            SpawnDefender(gridPos); // spawn the defender
            starDisplay.SpendStars(defenderCost); // spend stars
        }
        else
        {
            Debug.Log("Not enough stars!!!");
        }
    }
    
    private Vector2 GetSquareClicked() // Получаем квадрат
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // Программа предложила сделать это
        // --------------------------------
        Debug.Assert(Camera.main != null, "Camera.main != null");
        // --------------------------------
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos); // Приведение позици к сетке
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)  // Приведение позици к сетке
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    
    private void SpawnDefender(Vector2 roundedPos) // Создание Защитника
    {
        Defender newDefener = Instantiate(_defender, roundedPos, Quaternion.identity) as Defender;
    }
}
