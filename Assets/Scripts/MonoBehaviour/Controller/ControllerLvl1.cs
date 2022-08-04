using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLvl1 : MonoBehaviour
{
    private void Start()
    {
        TurnOffAllSpawners();
    }

    private void Update()
    {
        InclusionOfSpawners();
    }

    public void InclusionOfSpawners()
    {
        switch (FindObjectOfType<GameTimer>().GetRatioOfTime())
        {
            case 0:
                GameObject.Find("Spawners").transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 20:
                GameObject.Find("Spawners").transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 40:
                GameObject.Find("Spawners").transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 60:
                GameObject.Find("Spawners").transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 80:
                GameObject.Find("Spawners").transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    public void TurnOffAllSpawners()
    {
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.gameObject.SetActive(false);
        }
    }
}
