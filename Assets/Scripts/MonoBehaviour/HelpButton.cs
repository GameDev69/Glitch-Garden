using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private GameObject newInScene;

    private void OnMouseDown()
    {
        OpenCanvas();
    }

    public void CloseCanvas()
    {
        newInScene.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenCanvas()
    {
        newInScene.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Opened!");
    }
}
