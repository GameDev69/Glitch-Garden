using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] private Defenders defender;
    private int _starCost;

    private void Start()
    {
        _starCost = defender.StarsCost;
    }

    public int GetStarCost()
    {
        return defender.StarsCost;
    }
    
    public void AddStars()
    {
        FindObjectOfType<StarDisplay>().AddStars(defender.AddStars);
    }

    
}
