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
    [SerializeField] private int addStars;

    public int AddStars => addStars;
    public float Damage => damage;
    public int StarsCost => starsCost;
    public float HealthPoints => healthPoints;
    public GameObject DeathVFX => deathVFX; // Не удалять! На будущее
}
