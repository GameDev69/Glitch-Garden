using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defender")]
public class Defenders : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private int starsCost;
    [SerializeField] private float healthPoints;
    [SerializeField] private GameObject deathVFX;
    public float Damage => damage;
    public int StarsCost => starsCost;
    public float HealthPoints => healthPoints;
    public GameObject DeathVFX => deathVFX;
}
