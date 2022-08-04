using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacker")]
public class Attackers : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float healthPoints;
    [SerializeField] private float currentSpeed;
    [SerializeField] private GameObject deathVFX;

    public GameObject DeathVFX => deathVFX;
    public float Damage => damage;
    public float HealthPoints => healthPoints;
    public float CurrentSpeed => currentSpeed;
}
