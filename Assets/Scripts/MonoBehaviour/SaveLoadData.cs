using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO Delete this script from Level Controller Prefab 

public class SaveLoadData : MonoBehaviour
{
    private GameProgression _gameProgression;
    private string _dataPath;

    private void Start()
    {
        _gameProgression = FindObjectOfType<GameProgression>();
        _dataPath = Application.persistentDataPath + "/Saved Data.dat";
        OnStartScene();
    }

    private void OnStartScene()
    {
        if (SceneManager.GetActiveScene().name == "Start Scene")
        {
            LoadData();
        }
    }
    
    public void SaveData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter(); 
        FileStream savedData = File.Create(_dataPath); 
        DataSaver dataSaver = new DataSaver();
        if (dataSaver.savedPassedLevel < _gameProgression.LastPassedLevel)
        {
            dataSaver.savedPassedLevel = _gameProgression.LastPassedLevel;
            binaryFormatter.Serialize(savedData, dataSaver);
            Debug.Log("Game data saved!");
            Debug.Log(dataSaver.savedPassedLevel);
        }
        savedData.Close();
        
    }
    
    public void LoadData()
    {
        if (File.Exists(_dataPath)) 
        { 
            BinaryFormatter binaryFormatter = new BinaryFormatter(); 
            FileStream loadedFile = File.Open(_dataPath, FileMode.Open); 
            DataSaver loadedData = (DataSaver)binaryFormatter.Deserialize(loadedFile); 
            loadedFile.Close(); 
            _gameProgression.LastPassedLevel = loadedData.savedPassedLevel; 
            Debug.Log(_gameProgression.LastPassedLevel);
            Debug.Log("Game data loaded!"); 
        }
        else 
            Debug.LogError("There is no save data!");
    }

    public void ResetGameData()
    {
        if (File.Exists(_dataPath))
        {
            File.Delete(_dataPath);
        }
        _gameProgression.LastPassedLevel = 0;
    }
}
